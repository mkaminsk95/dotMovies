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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MovieDBService MovieService;

        [FromQuery(Name = "title")]
        public string Title { get; set; }
        [FromQuery(Name = "year")]
        public int Year { get; set; }


        public IEnumerable<Movie> Movies { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, MovieDBService movieService) {

            _logger = logger;
            MovieService = movieService;
         }



        public void OnGet() {

            Console.WriteLine(Title);
            if (Title == "")
                Movies = MovieService.GetMovies();
            else
                Movies = MovieService.GetMovies(Title);
        }

        
    }
}
