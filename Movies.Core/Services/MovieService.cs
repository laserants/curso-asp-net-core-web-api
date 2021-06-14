using Movies.Core.Entities;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(Movie entity)
        {
            if (entity == null)
            {
                return await _movieRepository.GetAllAsync();
            }
            return await _movieRepository.GetAsync(entity);
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> AddMovieAsync(Movie entity)
        {
            return await _movieRepository.AddAsync(entity);
        }

        public async Task<Movie> UpdateMovieAsync(Movie entity)
        {
            return await _movieRepository.UpdateAsync(entity);
        }

        public async Task<Movie> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteAsync(id);
        }
    }
}
