﻿using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(Movie entity);
        Task<Movie> GetMovieAsync(int id);
        Task<Movie> AddMovieAsync(Movie entity);
        Task<Movie> UpdateMovieAsync(Movie entity);
        Task<Movie> DeleteMovieAsync(int id);
    }
}
