using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;

namespace SportShoes2026.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoesDbContext _context;

        public UnitOfWork(ShoesDbContext context, IBrandRepository brands, ISportRepository sports, ISizeRepository sizes, ISportShoeRepository sportShoes, IGenreRepository genres)
        {
            _context = context;
            Brands = brands;
            Sports = sports;
            Sizes = sizes;
            SportShoes = sportShoes;
            Genres = genres;

        }

        public IBrandRepository Brands { get; }

        public ISportRepository Sports { get; }

        public ISizeRepository Sizes { get; }

        public ISportShoeRepository SportShoes { get; }
        public IGenreRepository Genres { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            foreach (var item in _context.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.State=EntityState.Unchanged;
                        item.CurrentValues.SetValues(item.OriginalValues);
                        break;
                    case EntityState.Added:
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
