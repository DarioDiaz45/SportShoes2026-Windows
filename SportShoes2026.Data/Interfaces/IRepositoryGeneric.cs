using Microsoft.Identity.Client;
using SportShoes2026.Entities;
using System.Linq.Expressions;

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

        (List<T> lista, int totalRegistros) ObtenerPagina(int pagina,
            int cantidad,
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor,
            Expression<Func<T, bool>>? filtrarPor = null);


    }
}
