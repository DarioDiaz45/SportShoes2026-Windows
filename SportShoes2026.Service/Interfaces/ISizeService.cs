using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Size;

namespace SportShoes2026.Service.Interfaces
{
    public interface ISizeService
    {
        Result<List<SizeListDto>> FilterByAsset(bool active);
        Result<List<SizeListDto>> GetAll();
        Result Add(SizeCreateDto dto);
        Result Delete(SizeDeleteDto sizeDeleteDto);

        Result<SizeUpdateDto> GetForUpdate(int id);

        Result Update(SizeUpdateDto dto);
        Result<SizeDeleteDto> GetForDelete(int id);
    }
}
