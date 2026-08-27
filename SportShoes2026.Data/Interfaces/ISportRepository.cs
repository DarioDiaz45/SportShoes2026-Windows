using SportShoes2026.Entities;
using System.Linq.Expressions;

namespace SportShoes2026.Data.Interfaces
{
    public interface ISportRepository : IRepositoryConcurrent<Sport>
    {
        bool ExistSameName(string name, int? sportId = null);

        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Sport, bool>>? filtrarPor = null);

        bool HasSportShoes(int id);

        bool Existe(Sport sport);
    }
}
   
    
