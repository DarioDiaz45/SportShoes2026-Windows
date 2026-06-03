namespace SportShoes2026.Service.DTOs.Sport
{
    public class SportListDto
    {
        public int SportId { get; set; }
        public string SportName { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
