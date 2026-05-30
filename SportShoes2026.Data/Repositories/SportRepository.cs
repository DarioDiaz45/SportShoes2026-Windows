using Microsoft.EntityFrameworkCore;
using SportShoes2026.Data.Interfaces;
using SportShoes2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportShoes2026.Data.Repositories
{
    public class SportRepository :RepositoryGeneric<Sport>, ISportRepository
    {
        public SportRepository(ShoesDbContext context) : base(context)
        {
        }

        public bool ExistSameName(string name, int? sportId = null)
        {
            return _context.Sports.Any(s =>
                 s.SportName == name &&
                 (sportId == null || s.SportId != sportId));
        }

        public bool HasSportShoes(int id)
        {
            return _context.SportShoes
                .Any(s => s.SportId == id);
        }
    }
}
