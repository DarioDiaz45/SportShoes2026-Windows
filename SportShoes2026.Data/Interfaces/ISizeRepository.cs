using SportShoes2026.Entities;
using System.Drawing;

namespace SportShoes2026.Data.Interfaces
{
    public interface ISizeRepository:IRepositoryConcurrent<SiZe>
    {
        bool ExistSameNumber(decimal number, int? sizeId = null);
    }
}

