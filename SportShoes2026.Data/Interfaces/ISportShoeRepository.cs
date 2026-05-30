using SportShoes2026.Entities;

namespace SportShoes2026.Data.Interfaces
{
    public interface ISportShoeRepository: IRepositoryGeneric<SportShoe>
    {

        bool ExistSameSportShoe(string model, int brandId, int sizeId, int? sportShoeId = null);

        List<SportShoe> GetByBrand(int brandId);

        List<SportShoe> GetBySport(int sportId);

        List<SportShoe> GetBySize(int sizeId);

        List<SportShoe> OrderByModel();

        List<SportShoe> OrderByPrice();

        List<SportShoe> OrderByBrand();
    }
}
