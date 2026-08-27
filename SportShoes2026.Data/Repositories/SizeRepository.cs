using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;
using System.Linq.Expressions;


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
        public int ObtenerPosicionRegistro(int seleccionadoId,
           Expression<Func<SiZe, bool>>? filtrarPor = null)
        {
            var sizeEnDb = GetById(seleccionadoId);
            if (sizeEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.SizeNumber.ToString(), sizeEnDb.SizeNumber.ToString()) <= 0);
        }

    }
}
