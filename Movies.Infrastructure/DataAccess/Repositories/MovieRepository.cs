using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> AddAsync(Movie entity)
        {
            var result = await _dbContext.Movies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> DeleteAsync(int id)
        {
            var result = await _dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (result != null)
            {
                _dbContext.Movies.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var allMovies = await _dbContext.Movies.ToListAsync();
            return allMovies;
        }

        public async Task<IEnumerable<Movie>> GetAsync(Movie entity)
        {
            List<Movie> movies = null;
            if (entity != null)
            {
                movies = await _dbContext.Movies.Where(
                    m => m.Title.ToLower().Contains(entity.Title.ToLower()) && 
                    m.Director.ToLower().Contains(entity.Director.ToLower())).ToListAsync();
            }
            return movies;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> UpdateAsync(Movie entity)
        {
            var result = await _dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == entity.Id);

            if (result != null)
            {
                result.Title = entity.Title;
                result.Year = entity.Year;
                result.Director = entity.Director;
                result.ImdbId = entity.ImdbId;
                result.Rating = entity.Rating;
                result.Genres = entity.Genres;
                result.RunTime = entity.RunTime;
                result.Country = entity.Country;
                result.Language = entity.Language;
                result.ImdbScore = entity.ImdbScore;
                result.ImdbVotes = entity.ImdbVotes;
                result.MetacriticScore = entity.MetacriticScore;

                await _dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
