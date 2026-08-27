using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data;
using SportShoes2026.Entities;
using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Service.Mappers;
using System.Linq.Expressions;

namespace SportShoes2026.Service.Services
{
    public class SportService : ISportService
    {
        private readonly IUnitOfWork _uow;

        private readonly IValidator<Sport> _validator;

        public SportService(IUnitOfWork uow, IValidator<Sport> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public Result<int> Add(SportCreateDto dto)
        {
            try
            {
                var sport = SportMapper.ToEntity(dto);
                var result = _validator.Validate(sport);
                if (!result.IsValid)
                {
                    return Result<int>.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
                }
                if (_uow.Sports.Existe(sport))
                {
                    return Result<int>.Failure($"Ya existe un deporte {sport.SportName}");
                }
                _uow.Sports.Add(sport);
                _uow.Save();
                return Result<int>.Success(sport.SportId);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tipo de bombón: {ex.Message}");
            }
        }

        public Result Delete(SportDeleteDto sportDeleteDto)
        {
            try
            {
                _uow.Sports.Delete(sportDeleteDto.SportId, sportDeleteDto.RowVersion);
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
                return Result.Failure(@$"Sport con ID: {sportDeleteDto.SportId}not found");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure($"Error trying to delete a sport {ex.Message}");
            }
        }



        public Result<List<SportListDto>> FilterByAsset(bool active)
        {
            try
            {
                var query = _uow.Sports.Query();
                var lista = query.Where(s => s.Active == active);
                var listaDto = lista.Select(s => SportMapper.ToListDto(s)).ToList();
                return Result<List<SportListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {

                return Result<List<SportListDto>>.Failure($"Error trying to filter Sport types: {ex.Message}");
            }
        }

        public Result<List<SportListDto>> GetAll()
        {
            var sports = _uow.Sports
                .GetAll()
                .Select(SportMapper.ToListDto)
                .ToList();

            return Result<List<SportListDto>>
                .Success(sports);
        }

        public Result<SportDeleteDto> GetForDelete(int id)
        {
            var sport = _uow.Sports.GetById(id);

            if (sport == null)
            {
                return Result<SportDeleteDto>.Failure("Sport not found");
            }

            return Result<SportDeleteDto>.Success(SportMapper.ToDeleteDto(sport));
        }

        public Result<SportUpdateDto> GetForUpdate(int id)
        {
            var sport = _uow.Sports.GetById(id);

            if (sport == null)
            {
                return Result<SportUpdateDto>
                    .Failure("Sport not found");
            }

            return Result<SportUpdateDto>.Success(SportMapper.ToUpdateDto(sport));
        }

        public Result<PaginationResultDto<SportListDto>> ObtenerPagina(int pagina, int cantidad, string campoOrdenar, bool esAscendente, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Sport, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = s => s.Active == filtroActivo;
                }

                Func<IQueryable<Sport>, IOrderedQueryable<Sport>>? ordenarPor = null;
                switch (campoOrdenar)
                {
                    case "SportId":
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(s => s.SportId) :
                            q.OrderByDescending(s => s.SportId);
                        break;
                    case "Name":
                    default:
                        ordenarPor = q => esAscendente ?
                            q.OrderBy(s => s.SportName) :
                            q.OrderByDescending(s => s.SportName);

                        break;
                }
                var resultado = _uow.Sports
                    .ObtenerPagina(pagina, cantidad, ordenarPor,
                        filtrarPor);
                var listaDto = resultado.lista
                    .Select(s => SportMapper.ToListDto(s))
                    .ToList();
                var resultadoPaginado = new
                   PaginationResultDto<SportListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };
                return Result<PaginationResultDto<SportListDto>>
                    .Success(resultadoPaginado);
            }
            catch (Exception ex)
            {

                return Result<PaginationResultDto<SportListDto>>
                    .Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Sport, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = s => s.Active == filtroActivo;
                }
                var posicion = _uow.Sports.ObtenerPosicionRegistro(seleccionadoId, filtrarPor);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {

                return Result<int>
                    .Failure($"Error al intentar obtener la pagina: {ex.Message}");
            }
        }

        public Result Update(SportUpdateDto dto)
        {
            var sport =
                _uow.Sports.GetById(dto.SportId);

            if (sport == null)
            {
                return Result.Failure(
                    "Sport not found");
            }

            sport.SportName = dto.SportName;
            sport.Active = dto.IsActive;

            if (_uow.Sports
                .ExistSameName(
                    sport.SportName,
                    sport.SportId))
            {
                return Result.Failure(
                    "Sport already exists");
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
