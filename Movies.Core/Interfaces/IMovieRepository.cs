using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAsync(Movie entity);
        Task<Movie> AddAsync(Movie entity);
        Task<Movie> UpdateAsync(Movie entity);
        Task<Movie> DeleteAsync(int id);
    }
}
