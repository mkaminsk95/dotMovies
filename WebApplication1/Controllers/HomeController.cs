using dotMovies.Models;
using dotMovies.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Controllers {
    public class HomeController : Controller {


        private MoviesService _movieService;

        public HomeController (MoviesService movieService) {

            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index() {

            ViewBag.MoviesList = _movieService.GetTop100Movies(); ;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string title, int? year, string genre) {

            ViewBag.MoviesList = _movieService.GetSpecificMovies(title, year, genre);

            return View();
        }

        [HttpGet]
        [Route("movie/{movieId:int}")]
        public IActionResult Movie(int movieId) {

            ViewBag.Movie = _movieService.GetMovieWithGenres(movieId);

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

    }
}
