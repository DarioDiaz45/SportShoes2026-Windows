using SportShoes2026.Entities.Interface;

namespace SportShoes2026.Data.Interfaces
{
    public interface IRepositoryConcurrent<T>:IRepositoryGeneric<T> where T : class, IConcurrencyEntity
    {
        void Delete(int id, byte[] rowVersion);
        void Update(T entity,int id , byte[] rowVersion);
    }
}
