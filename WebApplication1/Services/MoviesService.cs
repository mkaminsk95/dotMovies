using dotMovies.Models;
using dotMovies.Data;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace dotMovies.Services {
    public class MoviesService {

        private string _connectionString = "server=localhost;user id=root;database=dotmoviesdb;allowuservariables=True;password=movieDBpassword";
        private MySqlConnection _connection;
        private MoviesDBContext _context;

        public MoviesService(IWebHostEnvironment webHostEnvironment, 
                            MoviesDBContext moviesDBContext) {
            WebHostEnvironment = webHostEnvironment;
            _connection = new MySqlConnection(_connectionString);
            _context = moviesDBContext;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public List<Movie> GetTop100Movies() {
            
            return _context.Movies.OrderByDescending(u => u.AverageScore).Take(100).ToList();
        }

        public Movie GetMovie(int movieId) {

            return _context.Movies.Find(movieId);
        }

      
        public Movie GetMovieWithGenres(int movieId) {

            return _context.Movies.Include(m => m.Genres).Where(m => m.ID == movieId).First();
        }
        

        public List<Movie> GetSpecificMovies(string title, int? year, string genre) {

            IQueryable<Movie> query = _context.Movies;

            if (title != null)
                query = query.Where(m => m.Title.Contains(title));

            if (year != null)
                query = query.Where(m => m.Year == year);

            if (genre != null)
                query = query.Where(m => m.Genres.Where(g => g.Genre == genre).Any());

            var movies = query.OrderByDescending(m => m.AverageScore).Take(100).ToList();
            
            
            return movies;
        }

    }
}
