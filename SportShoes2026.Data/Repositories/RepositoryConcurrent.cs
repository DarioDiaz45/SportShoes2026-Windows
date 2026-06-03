using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities.Interface;
using System.Diagnostics.CodeAnalysis;

namespace SportShoes2026.Data.Repositories
{
    public class RepositoryConcurrent<T> : RepositoryGeneric<T>, IRepositoryConcurrent<T> where T : class, IConcurrencyEntity
    {
        public RepositoryConcurrent(ShoesDbContext context) : base(context)
        {
        }
        public override void Delete(int id)
        {
            throw new NotImplementedException($"You must use the concurrency version");
        }
        public void Delete(int id, byte[] rowVersion)
        {
            var entityinDb = _dbSet.Find(id);
            if (entityinDb is null)
            {
                throw new KeyNotFoundException($"The entity ID could not be deleted:{id} from the table {typeof(T).Name}");
            }
            var entity=_dbSet.Entry(entityinDb);
            entity.CurrentValues["RowVersion"] = rowVersion;

            _dbSet.Remove(entityinDb);
        }

        public void Update(T entity, int id, byte[] rowVersion)
        {
            var entityInDb = _dbSet.Find(id);
            if (entityInDb is null)
            {
                throw new KeyNotFoundException($"The entity ID could not be update:{id} from the table {typeof(T).Name}");
            }
            var entityE = _dbSet.Entry(entityInDb);
            entityE.CurrentValues["RowVersion"] = rowVersion;
            _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);
        }
    }
}
