using SportShoes2026.Entities;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.DTOs.Sport;
using System.Drawing;

namespace SportShoes2026.Service.Mappers
{
    public static class SizeMapper
    {
        public static SizeListDto ToListDto(SiZe size)
        {
            return new SizeListDto
            {
                SizeId = size.SizeId,
                Number = size.SizeNumber,
                IsActive = size.Active
            };

        }
        public static SizeUpdateDto ToUpdateDto(SiZe size)
        {
            return new SizeUpdateDto
            {
                SizeId = size.SizeId,
                Number = size.SizeNumber,
                IsActive = size.Active

            };
        }

        internal static SiZe ToEntity(SizeCreateDto dto)
        {
            return new SiZe
            {
                SizeNumber = dto.Number,
                Active = true
            };
        }
        public static SizeDeleteDto ToDeleteDto(SiZe size)
        {
            return new SizeDeleteDto
            {
                SizeId = size.SizeId,
                RowVersion = size.RowVersion
            };
        }
    }
}
