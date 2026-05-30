using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Repositories
{
    public class BrandRepository : RepositoryGeneric<Brand>, IBrandRepository
    {
        public BrandRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool ExistSameName(string name, int? brandId = null)
        {
            return _context.Brands.Any(b =>
                b.BrandName == name &&
                (brandId == null || b.BrandId != brandId));
        }


        public bool HasSportShoes(int id)
        {
            return _context.SportShoes.Any(s => s.BrandId == id);
        }


    }
}
