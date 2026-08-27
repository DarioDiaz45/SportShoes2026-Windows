using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;

namespace SportShoes2026.Service.Interfaces
{
    public interface IBrandService
    {



        Result<List<BrandListDto>> GetAll();

        Result<int> Add(BrandCreateDto dto);

        Result Delete(BrandDeleteDto dto);

        Result<BrandUpdateDto> GetForUpdate(int id);
        Result<BrandDeleteDto> GetForDelete(int id);

        Result Update(BrandUpdateDto dto);

        Result<List<BrandListDto>> FilterByAsset(bool active);
        Result<PaginationResultDto<BrandListDto>> ObtenerPagina(int pagina,
           int cantidad, string campoOrdenar, bool esAscendente,
           bool? filtroActivo = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId,
                                          int cantidadPorPagina,
                                          bool? filtroActivo = null);
    }
}
