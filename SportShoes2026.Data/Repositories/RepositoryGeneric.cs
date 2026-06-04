using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data.Interfaces;

namespace SportShoes2026.Data.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected readonly ShoesDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryGeneric(ShoesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"The entity ID could not be deleted:{id} from the table {typeof(T).Name}");
            }
            _dbSet.Remove(entity);
        }

        public List<T> GetAll()
        {

            return _dbSet.AsNoTracking().ToList();

        }

        public T? GetById(int id)
        {

            return _dbSet.Find(id);

        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking();
        }

        public void Update(T entity, int id)
        {

            var entityInDb = _dbSet.Find(id);
            if (entityInDb is null)
            {
                throw new KeyNotFoundException($"The entity ID could not be updated:{id} from the table {typeof(T).Name}");
            }
            _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);

        }
    }
}
