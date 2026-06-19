using SportShoes2026.Data;
using SportShoes2026.Service.DTOs.Genre;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportShoes2026.Service.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _uow;

        public GenreService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<GenreListDto> GetList()
        {
            return _uow.Genres
            .GetAll()
            .Select(GenreMapper.ToListDto)
            .ToList();
        }
    }
}
