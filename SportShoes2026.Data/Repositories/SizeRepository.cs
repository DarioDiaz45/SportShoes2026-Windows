using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;


namespace SportShoes2026.Data.Repositories
{
    public class SizeRepository : RepositoryConcurrent<SiZe>, ISizeRepository
    {
        public SizeRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool ExistSameNumber(decimal number, int? sizeId = null)
        {
            return _context.SiZes.Any(s =>
                s.SizeNumber == number &&
                (sizeId == null ||
                 s.SizeId != sizeId));
        }

    }
}
