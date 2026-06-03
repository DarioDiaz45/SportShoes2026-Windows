using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Sport;

namespace SportShoes2026.Service.Interfaces
{
    public interface ISportService
    {
        Result<List<SportListDto>> GetAll();

        Result Add(SportCreateDto dto);

        Result Delete(SportDeleteDto dto);

        Result<SportUpdateDto> GetForUpdate(int id);

        Result<SportDeleteDto> GetForDelete(int id);
        Result Update(SportUpdateDto dto);
        Result<List<SportListDto>> FilterByAsset(bool active);
        
    }
}
