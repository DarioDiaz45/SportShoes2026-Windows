using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data;
using SportShoes2026.Entities;
using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Service.Mappers;
using System.Linq.Expressions;

namespace SportShoes2026.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _uow;

        private readonly IValidator<Brand> _validator;
        public BrandService(IUnitOfWork uow, IValidator<Brand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public Result<int> Add(BrandCreateDto dto)
        {
            try
            {
                var brand = BrandMapper.ToEntity(dto);
                var result = _validator.Validate(brand);
                if (!result.IsValid)
                {
                    return Result<int>.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
                }
                if (_uow.Brands.Existe(brand))
                {
                    return Result<int>.Failure($"Ya existe una marca {brand.BrandName}");
                }
                _uow.Brands.Add(brand);
                _uow.Save();
                return Result<int>.Success(brand.BrandId);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tipo de bombón: {ex.Message}");
            }
        }

        public Result Delete(BrandDeleteDto brandDeleteDto)
        {
            try
            {
                _uow.Brands.Delete(brandDeleteDto.BrandId, brandDeleteDto.RowVersion);
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
                return Result.Failure(@$"Brand con ID: {brandDeleteDto.BrandId} not found");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure($"Error trying to delete a brand {ex.Message}");
            }
        }

        public Result<List<BrandListDto>> FilterByAsset(bool active)
        {
            try
            {
                var query = _uow.Brands.Query();
                var lista = query.Where(s => s.Active == active);
                var listaDto = lista.Select(s => BrandMapper.ToListDto(s)).ToList();
                return Result<List<BrandListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {

                return Result<List<BrandListDto>>.Failure($"Error trying to filter Brand types: {ex.Message}");
            }
        }

        public Result<List<BrandListDto>> GetAll()
        {
            var brands = _uow.Brands
                .GetAll()
                .Select(BrandMapper.ToListDto)
                .ToList();

            return Result<List<BrandListDto>>.Success(brands);
        }

        public Result<BrandDeleteDto> GetForDelete(int id)
        {
            var brand = _uow.Brands.GetById(id);

            if (brand == null)
            {
                return Result<BrandDeleteDto>.Failure("Brand not found");
            }

            return Result<BrandDeleteDto>.Success(BrandMapper.ToDeleteDto(brand));
        }

        public Result<BrandUpdateDto> GetForUpdate(int id)
        {
            var brand = _uow.Brands.GetById(id);

            if (brand == null)
            {
                return Result<BrandUpdateDto>
                    .Failure("Brand not found");
            }

            return Result<BrandUpdateDto>
                .Success(BrandMapper.ToUpdateDto(brand));
        }

        public Result<PaginationResultDto<BrandListDto>> ObtenerPagina(int pagina, int cantidad, string campoOrdenar, bool esAscendente, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Brand, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Active == filtroActivo;
                }

                Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? ordenarPor = null;
                switch (campoOrdenar)
                {
                    case "BrandId":
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(b => b.BrandId) :
                            q.OrderByDescending(b => b.BrandId);
                        break;
                    case "Nombre":
                    default:
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(b => b.BrandName) :
                            q.OrderByDescending(b => b.BrandName);

                        break;
                }
                var resultado = _uow.Brands
                    .ObtenerPagina(pagina, cantidad, ordenarPor,
                        filtrarPor);
                var listaDto = resultado.lista
                    .Select(b => BrandMapper.ToListDto(b))
                    .ToList();
                var resultadoPaginado = new
                   PaginationResultDto<BrandListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };
                return Result<PaginationResultDto<BrandListDto>>
                    .Success(resultadoPaginado);
            }
            catch (Exception ex)
            {

                return Result<PaginationResultDto<BrandListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Brand, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Active == filtroActivo;
                }
                var posicion = _uow.Brands.ObtenerPosicionRegistro(seleccionadoId, filtrarPor);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {

                return Result<int>
                    .Failure($"Error al intentar obtener la pagina: {ex.Message}");
            }
        }








        public Result Update(BrandUpdateDto dto)
        {
            var brand = _uow.Brands.GetById(dto.BrandId);

            if (brand == null)
            {
                return Result.Failure("Brand not found");
            }

            brand.BrandName = dto.BrandName;
            brand.Country = dto.Country;
            brand.Active = dto.Active;

            if (_uow.Brands.ExistSameName(brand.BrandName, brand.BrandId))
            {
                return Result.Failure("Brand already exists");
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
    }

}
