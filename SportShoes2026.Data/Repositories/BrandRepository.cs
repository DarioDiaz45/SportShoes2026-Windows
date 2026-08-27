using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;
using System.Linq.Expressions;

namespace SportShoes2026.Data.Repositories
{
    public class BrandRepository : RepositoryConcurrent<Brand>, IBrandRepository
    {
        public BrandRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool Existe(Brand brand)
        {
            return _context.Brands
                .Any(b => b.BrandName == brand.BrandName &&
                b.BrandId != brand.BrandId);
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
        public int ObtenerPosicionRegistro(int seleccionadoId,
           Expression<Func<Brand, bool>>? filtrarPor = null)
        {
            var brandEnDb = GetById(seleccionadoId);
            if (brandEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.BrandName, brandEnDb.BrandName) <= 0);
        }

    }
}
