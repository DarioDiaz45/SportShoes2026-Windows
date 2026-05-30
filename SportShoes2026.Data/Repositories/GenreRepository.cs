using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Repositories
{
    public class GenreRepository : RepositoryGeneric<Genre>, IGenreRepository
    {
        public GenreRepository(ShoesDbContext context) : base(context)
        {
        }
    }
}
