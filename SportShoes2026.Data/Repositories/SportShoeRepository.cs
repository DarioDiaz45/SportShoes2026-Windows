using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Repositories
{
    public class SportShoeRepository : RepositoryConcurrent<SportShoe>, ISportShoeRepository
    {
        public SportShoeRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool ExistSameSportShoe(
            string model,
            int brandId,
            int sizeId,
            int? sportShoeId = null)
        {
            return _context.SportShoes.Any(s =>
                s.Model == model &&
                s.BrandId == brandId &&
                s.GenreId == sizeId &&
                (sportShoeId == null ||
                 s.ShoeId != sportShoeId));
        }


        public List<SportShoe> GetByBrand(int brandId)
        {
            return _context.SportShoes.Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .Where(s => s.BrandId == brandId && s.Active)
                .AsNoTracking()
                .ToList();
        }



        public List<SportShoe> GetBySize(int sizeId)
        {
            return _context.SportShoes.Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .Where(s => s.SizeId == sizeId && s.Active)
                .AsNoTracking()
                .ToList();

        }

        public List<SportShoe> GetBySport(int sportId)
        {
            return _context.SportShoes.Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .Where(s => s.SportId == sportId && s.Active)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> OrderByBrand()
        {
            return _context.SportShoes.Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .Where(s => s.Active)
                .OrderBy(s => s.Brand.BrandName)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> OrderByModel()
        {
            return _context.SportShoes.Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .Where(s => s.Active)
                .OrderBy(s => s.Model)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> OrderByPrice()
        {
            return _context.SportShoes.Include(s => s.Brand)
                    .Include(s => s.Size)
                    .Include(s => s.Sport)
                    .Include(s => s.Genre)
                    .Where(s => s.Active)
                    .OrderBy(s => s.Price)
                    .AsNoTracking()
                    .ToList();
        }



    }
}
