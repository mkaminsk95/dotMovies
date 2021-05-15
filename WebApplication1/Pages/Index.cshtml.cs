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

namespace dotMovies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MovieDBService MovieService;

        public IEnumerable<Movie> Movies { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, MovieDBService movieService) {

            _logger = logger;
            MovieService = movieService;
         }
        
        public void OnGet() {
            
            Movies = MovieService.GetMovies();
        }
    }
}
