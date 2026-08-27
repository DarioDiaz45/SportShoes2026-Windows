using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data;
using SportShoes2026.Entities;
using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Service.Mappers;
using System.Linq.Expressions;

namespace SportShoes2026.Service.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<SiZe> _validator;

        public SizeService(IUnitOfWork uow, IValidator<SiZe> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public Result<List<SizeListDto>> FilterByAsset(bool active)
        {
            try
            {
                var query = _uow.Sizes.Query();
                var lista = query.Where(s => s.Active == active);
                var listaDto = lista.Select(s => SizeMapper.ToListDto(s)).ToList();
                return Result<List<SizeListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {

                return Result<List<SizeListDto>>.Failure($"Error trying to filter Size types: {ex.Message}");
            }
        }

        public Result<List<SizeListDto>> GetAll()
        {
            var sizes = _uow.Sizes
            .GetAll()
            .Select(SizeMapper.ToListDto)
            .ToList();

            return Result<List<SizeListDto>>.Success(sizes);
        }

        public Result<SizeUpdateDto> GetForUpdate(int id)
        {
            var size = _uow.Sizes.GetById(id);

            if (size == null)
            {
                return Result<SizeUpdateDto>
                    .Failure("Size not found");
            }

            return Result<SizeUpdateDto>.Success(SizeMapper.ToUpdateDto(size));
        }

        public Result Update(SizeUpdateDto dto)
        {
            var size = _uow.Sizes.GetById(dto.SizeId);

            if (size == null)
            {
                return Result.Failure("Size not found");
            }

            size.SizeNumber = dto.Number;
            size.Active=dto.IsActive;

            var validation =
                _validator.Validate(size);

            if (!validation.IsValid)
            {
                return Result.Failure(validation.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (_uow.Sizes.ExistSameNumber(
                size.SizeNumber,
                size.SizeId))
            {
                return Result.Failure("Size already exists");
            }

            try
            {
                _uow.Save();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
        public Result <int>Add(SizeCreateDto dto)
        {
            try
            {
                var size = SizeMapper.ToEntity(dto);
                var result = _validator.Validate(size);
                if (!result.IsValid)
                {
                    return Result<int>.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
                }
                if (_uow.Sizes.ExistSameNumber(size.SizeNumber))
                {
                    return Result<int>.Failure($"Ya existe un tamaño {size.SizeNumber}");
                }
                _uow.Sizes.Add(size);
                _uow.Save();
                return Result<int>.Success(size.SizeId);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tipo de bombón: {ex.Message}");
            }
        }
        public Result Delete(SizeDeleteDto sizeDeleteDto)
        {
            try
            {
                _uow.Sizes.Delete(sizeDeleteDto.SizeId, sizeDeleteDto.RowVersion);
                _uow.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _uow.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");

            }
            catch (KeyNotFoundException)
            {
                _uow.RollBack();
                return Result.Failure(@$"Sport con ID: {sizeDeleteDto.SizeId}not found");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure($"Error trying to delete a sport {ex.Message}");
            }
        }

        public Result<SizeDeleteDto> GetForDelete(int id)
        {
            var size = _uow.Sizes.GetById(id);

            if (size == null)
            {
                return Result<SizeDeleteDto>.Failure("Size not found");
            }

            return Result<SizeDeleteDto>.Success(SizeMapper.ToDeleteDto(size));
        }

        public Result<PaginationResultDto<SizeListDto>> ObtenerPagina(int pagina, int cantidad, string campoOrdenar, bool esAscendente, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<SiZe, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Active == filtroActivo;
                }

                Func<IQueryable<SiZe>, IOrderedQueryable<SiZe>>? ordenarPor = null;
                switch (campoOrdenar)
                {
                    case "SizeId":
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(b => b.SizeId) :
                            q.OrderByDescending(b => b.SizeId);
                        break;
                    case "Number":
                    default:
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(b => b.SizeNumber) :
                            q.OrderByDescending(b => b.SizeNumber);

                        break;
                }
                var resultado = _uow.Sizes
                    .ObtenerPagina(pagina, cantidad, ordenarPor,
                        filtrarPor);
                var listaDto = resultado.lista
                    .Select(b => SizeMapper.ToListDto(b))
                    .ToList();
                var resultadoPaginado = new
                   PaginationResultDto<SizeListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };
                return Result<PaginationResultDto<SizeListDto>>
                    .Success(resultadoPaginado);
            }
            catch (Exception ex)
            {

                return Result<PaginationResultDto<SizeListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<SiZe, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Active == filtroActivo;
                }
                var posicion = _uow.Sizes.ObtenerPosicionRegistro(seleccionadoId, filtrarPor);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {

                return Result<int>
                    .Failure($"Error al intentar obtener la pagina: {ex.Message}");
            }
        }
    }
}
