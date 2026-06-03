using SportShoes2026.Entities;

namespace SportShoes2026.Data.Interfaces
{
    public interface ISportRepository:IRepositoryConcurrent<Sport>
    {
        bool ExistSameName(string name, int? sportId = null);

        bool HasSportShoes(int id);
    }
}
