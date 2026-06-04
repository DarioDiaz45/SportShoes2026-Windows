using SportShoes2026.Entities;

namespace SportShoes2026.Data.Interfaces
{
    public interface IBrandRepository : IRepositoryConcurrent<Brand>
    {
        bool ExistSameName(string name, int? brandId = null);

        bool HasSportShoes(int id);
    }
}
