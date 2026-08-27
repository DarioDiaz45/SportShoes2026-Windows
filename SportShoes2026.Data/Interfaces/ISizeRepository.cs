using SportShoes2026.Entities;
using System.Drawing;
using System.Linq.Expressions;

namespace SportShoes2026.Data.Interfaces
{
    public interface ISizeRepository:IRepositoryConcurrent<SiZe>
    {
        bool ExistSameNumber(decimal number, int? sizeId = null);
        int ObtenerPosicionRegistro(int seleccionadoId,
           Expression<Func<SiZe, bool>>? filtrarPor = null);
    }
}

