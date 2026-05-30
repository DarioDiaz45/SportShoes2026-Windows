using Microsoft.Identity.Client;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class
    {
        List<T> GetAll();

        T? GetById(int id);

        IQueryable<T> Query();

        void Add(T entity);

        void Update(T entity,int id);

        void Delete(int id);

       
    }
}
