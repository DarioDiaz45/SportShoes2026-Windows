namespace SportShoes2026.Service.DTOs.Genre
{
    public class GenreListDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public bool Active { get; set; }
    }
}
