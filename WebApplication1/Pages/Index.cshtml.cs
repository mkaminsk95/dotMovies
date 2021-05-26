using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using dotMovies.Models;
using dotMovies.Services;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace dotMovies.Pages
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MoviesService MovieService;

        
        
        public string QueryTitle { get; set; }
        public int? QueryYear { get; set; }
        public string QueryGenre { get; set; }
        
        public IEnumerable<string> Genres = new string[]{ "Action", "Adventure", "Drama", "Science Fiction", "Comedy", "Romance", "Animation", "Family", "Fantasy",
                                                            "Crime", "Thriller", "Horror", "History", "Mystery", "War", "Music", "Documentary", "Western", "TV Movie"};
        public IEnumerable<Movie> Movies { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, MoviesService movieService) {


            _logger = logger;
            MovieService = movieService;
         }


        public void OnGet() {

            if (QueryTitle != null || QueryYear != null || QueryGenre != null)
                Movies = MovieService.GetSpecificMovies(QueryTitle, QueryYear, QueryGenre);
            else 
                Movies = MovieService.GetTop100Movies();
        }

    }
}
