namespace SportShoes2026.Service.DTOs.Size
{
    public class SizeCreateDto
    {
        public int SizeId { get; set; }
        public decimal Number { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
