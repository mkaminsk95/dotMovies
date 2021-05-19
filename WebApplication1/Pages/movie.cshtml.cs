using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotMovies.Models;
using dotMovies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace dotMovies.Pages
{
    public class MovieModel : PageModel {
        public MovieDBService MovieService;

        public Movie Movie { get; private set; }
        public List<string> GenreList;
        public string Budget, Revenue;

        public MovieModel(MovieDBService movieService) {
 
            MovieService = movieService;
        }

        public void OnGet(int id)
        {
            //int id = int.Parse((string)RouteData.Values["id"]);
            
            Movie = MovieService.GetMovie(id);
            GenreList = MovieService.GetMovieGenres(id);

            if (Movie.Budget != 0)
                Budget = Movie.Budget.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            else
                Budget = "unknown";

            if (Movie.Revenue != 0)
                Revenue = Movie.Revenue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            else
                Revenue = "unknown";

        }
    }
}