using SportShoes2026.Entities;
using System.Linq.Expressions;

namespace SportShoes2026.Data.Interfaces
{
    public interface IBrandRepository : IRepositoryConcurrent<Brand>
    {
        bool ExistSameName(string name, int? brandId = null);

        bool HasSportShoes(int id);
        bool Existe(Brand brand);

        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Brand, bool>>? filtrarPor = null);
    }
}
