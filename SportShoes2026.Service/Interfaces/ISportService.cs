using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Sport;

namespace SportShoes2026.Service.Interfaces
{
    public interface ISportService
    {
        Result<List<SportListDto>> GetAll();

        Result<int> Add(SportCreateDto dto);

        Result Delete(SportDeleteDto sportDeleteDto);

        Result<SportUpdateDto> GetForUpdate(int id);

        Result<SportDeleteDto> GetForDelete(int id);
        Result Update(SportUpdateDto dto);
        Result<List<SportListDto>> FilterByAsset(bool active);
        Result<PaginationResultDto<SportListDto>> ObtenerPagina(int pagina,
          int cantidad, string campoOrdenar, bool esAscendente,
          bool? filtroActivo = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId,
                                          int cantidadPorPagina,
                                          bool? filtroActivo = null);

    }
}
