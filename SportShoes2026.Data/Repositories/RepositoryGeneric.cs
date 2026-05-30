using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data.Interfaces;

namespace SportShoes2026.Data.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected readonly ShoesDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryGeneric(ShoesDbContext context )
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to add a record to the table {typeof(T).Name}",ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity=_dbSet.Find(id);
                if (entity is null)
                {
                    throw new KeyNotFoundException($"No se pudo borrar la entidad ID:{id} de la tabla {typeof(T).Name}");
                }
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to delete a record from the table {typeof(T).Name}", ex);

            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();

            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to retrieve records in the table {typeof(T).Name}", ex);
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to look for a record from the table {typeof(T).Name}", ex);

            }
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public void Update(T entity, int id)
        {
            try
            {
                var entityInDb = _dbSet.Find(id);
                if (entityInDb is null)
                {
                    return;
                }
                _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to update a record in the table {typeof(T).Name}", ex);
            }
        }
    }
}
