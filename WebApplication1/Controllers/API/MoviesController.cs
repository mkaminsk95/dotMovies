using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotMovies.Data;
using dotMovies.Models;
using System.Text.Json;
using System.Net;
using System.Net.Http;
using dotMovies.Services;

namespace dotMovies.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase {
        private readonly MoviesDBContext _context;
        private readonly MoviesService _moviesService;


        public MoviesController(MoviesDBContext context, MoviesService moviesService) {
            _context = context;
            _moviesService = moviesService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() {
            
            return await _moviesService.GetAllMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id) {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null) {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie) {
            
            if (id != movie.ID)
                return BadRequest("Movie ID mismatch");

            try {
                await _moviesService.PutMovie(movie);
            
            } catch (DbUpdateConcurrencyException) {
                if (!MovieExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

       
        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<string>> PostMovie(Movie newMovie)
        {

           await Task.Run( () => _moviesService.AddMovie(newMovie));
           return new ActionResult<string>("Model Valid");
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
