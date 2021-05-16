using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotMovies.Models;
using dotMovies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotMovies.Pages
{
    public class MovieModel : PageModel
    {
        public MovieDBService MovieService;

        public Movie Movie { get; private set; }

        public MovieModel(MovieDBService movieService) {
 
            MovieService = movieService;
        }

        public void OnGet()
        {
            int id = int.Parse((string)RouteData.Values["id"]);

            Movie = MovieService.GetMovie(id);
        }
    }
}