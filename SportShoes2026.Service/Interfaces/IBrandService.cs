using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Sport;

namespace SportShoes2026.Service.Interfaces
{
    public interface IBrandService
    {
        Result<List<BrandListDto>> GetAll();

        Result Add(BrandCreateDto dto);

        Result Delete(BrandDeleteDto dto);

        Result<BrandUpdateDto> GetForUpdate(int id);
        Result<BrandDeleteDto> GetForDelete(int id);

        Result Update(BrandUpdateDto dto);

        Result<List<BrandListDto>> FilterByAsset(bool active);
    }
}
