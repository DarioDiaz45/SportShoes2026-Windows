using SportShoes2026.Entities;
using SportShoes2026.Service.DTOs.Genre;

namespace SportShoes2026.Service.Mappers
{
    public class GenreMapper
    {
        public static GenreListDto ToListDto(Genre genre)
        {
            return new GenreListDto
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName,
                Active = genre.Active
            };
        }
    }
}
