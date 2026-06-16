namespace SportShoes2026.Service.DTOs.Brand
{
    public class BrandUpdateDto
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

    }
}
