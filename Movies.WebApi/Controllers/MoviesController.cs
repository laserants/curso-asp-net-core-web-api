using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Get movies.
        /// </summary>
        /// <remarks>
        /// If you didn't send paramaters the endpoint will return all movies.
        /// </remarks>
        /// <param name="title">Movie title</param>
        /// <param name="director">Movie director</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync(string title, string director)
        {
            Movie entity = null;
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(director))
            {
                entity = new Movie
                {
                    Title = title ?? string.Empty,
                    Director = director ?? string.Empty,
                };
            }
            var movies = await _movieService.GetMoviesAsync(entity);
            return Ok(movies);
        }

        /// <summary>
        /// Get a movie by Id.
        /// </summary>
        /// <remarks>
        /// Send the Id in URI.
        /// </remarks>
        /// <param name="id">Movie Id</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return Ok(movie);
        }

        /// <summary>
        /// Create a movie.
        /// </summary>
        /// <remarks>
        /// Send the Movie data in HTTP Request's body as JSON.
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie object is null");
            }
            var result = await _movieService.AddMovieAsync(movie);
            return Ok(result);
        }

        /// <summary>
        /// Update a movie.
        /// </summary>
        /// <remarks>
        /// Send the Movie data in HTTP Request's body as JSON.
        /// URI Id and Movie Id within JSON should match.
        /// </remarks>
        /// <param name="id">Movie Id</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Movie Id is different");
            }

            var result = await _movieService.UpdateMovieAsync(movie);
            if (result == null)
            {
                return NotFound($"Movie with Id = {id} not found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Delete a movie by Id.
        /// </summary>
        /// <remarks>
        /// Send the Id in URI.
        /// </remarks>
        /// <param name="id">Movie Id</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);
            if (result == null)
            {
                return NotFound($"Movie with Id = {id} not found");
            }
            return Ok($"Movie with Id = {id} deleted");
        }
    }
}
