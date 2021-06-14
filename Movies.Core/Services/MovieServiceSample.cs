using Movies.Core.Entities;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public class MovieServiceSample : IMovieService
    {
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return new List<Movie>()
            {
                new Movie() { Id = 1, Title = "Titanic", Year = 1998 },
                new Movie() { Id = 2, Title = "Star Wars", Year = 1978 },
                new Movie() { Id = 3, Title = "Space Jam", Year = 1996}
            };
        }

        public Task<Movie> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> AddMovieAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovieAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
