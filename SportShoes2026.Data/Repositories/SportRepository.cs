using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;
using System.Linq.Expressions;

namespace SportShoes2026.Data.Repositories
{
    public class SportRepository : RepositoryConcurrent<Sport>, ISportRepository
    {
        public SportRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool Existe(Sport sport)
        {
            return _context.Sports
                 .Any(s => s.SportName == sport.SportName &&
                 s.SportId != sport.SportId);
        }

        public bool ExistSameName(string name, int? sportId = null)
        {
            return _context.Sports.Any(s =>
                 s.SportName == name &&
                 (sportId == null || s.SportId != sportId));
        }

        public bool HasSportShoes(int id)
        {
            return _context.SportShoes
                .Any(s => s.SportId == id);
        }
        public int ObtenerPosicionRegistro(int seleccionadoId,
          Expression<Func<Sport, bool>>? filtrarPor = null)
        {
            var sportEnDb = GetById(seleccionadoId);
            if (sportEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.SportName, sportEnDb.SportName) <= 0);
        }
    }
}
