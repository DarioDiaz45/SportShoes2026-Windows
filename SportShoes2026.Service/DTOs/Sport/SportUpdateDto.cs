namespace SportShoes2026.Service.DTOs.Sport
{
    public class SportUpdateDto
    {
        public int SportId { get; set; }

        public string SportName { get; set; } = null!;

        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
