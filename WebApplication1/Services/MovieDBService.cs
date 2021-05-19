using dotMovies.Models;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Services {
    public class MovieDBService {

        private string _connectionString = "server=localhost;user id=root;database=dotmoviesdb;allowuservariables=True;password=movieDBpassword";
        private MySqlConnection _connection; 

        public MovieDBService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
            _connection = new MySqlConnection(_connectionString);
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public MySqlDataReader GetMovieDataFromDatabase(string queryString) {
       
            _connection.Open();

            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = queryString;

            MySqlDataReader movieDataReader = command.ExecuteReader();
            
            return movieDataReader;
        }

        public Movie GetMovie(int movieId) {

            Movie movie = new Movie();

            MySqlDataReader moviesReader = GetMovieDataFromDatabase($"SELECT * FROM movies WHERE movieId = {movieId}");

            moviesReader.Read();

            movie.MovieId = moviesReader.GetInt32(0);
            movie.Title = moviesReader.GetString(1);
            movie.Year = moviesReader.GetInt16(2);
            movie.Poster = moviesReader.GetString(3);
            movie.Director = moviesReader.GetString(4);
            movie.Screenplay = moviesReader.GetString(5);
            movie.Runtime = moviesReader.GetTimeSpan(6);
            movie.Budget = moviesReader.GetInt32(7);
            movie.Revenue = moviesReader.GetInt32(8);
            movie.AverageScore = moviesReader.GetFloat(9);

            _connection.Close();
            return movie;
        }

        public List<string> GetMovieGenres(int movieId) {

            List<string> genreList = new List<string>();

            MySqlDataReader moviesReader = GetMovieDataFromDatabase($"SELECT genre FROM dotmoviesdb.movie_genres WHERE movieId = {movieId}");

            while (moviesReader.Read()) 
                genreList.Add(moviesReader.GetString(0));
            
            _connection.Close();
            return genreList;
        }
    
        public List<Movie> GetTop100Movies() {
            MySqlDataReader moviesReader = GetMovieDataFromDatabase("SELECT * FROM movies ORDER BY averageScore DESC LIMIT 100");
            List<Movie> movies = MapDataReaderIntoMovieList(moviesReader);

            _connection.Close();
            return movies;
        }

        public List<Movie> GetSpecificMovies(string title) {
            MySqlDataReader moviesReader = GetMovieDataFromDatabase($"SELECT * FROM movies WHERE title LIKE '%{title}%' ORDER BY averageScore DESC LIMIT 100;");
            List<Movie> movies = MapDataReaderIntoMovieList(moviesReader);

            _connection.Close();
            return movies;
        }

        public List<Movie> GetSpecificMovies(int year) {
            MySqlDataReader moviesReader = GetMovieDataFromDatabase($"SELECT * FROM movies WHERE year = {year} ORDER BY averageScore DESC LIMIT 100;");
            List<Movie> movies = MapDataReaderIntoMovieList(moviesReader);

            _connection.Close();
            return movies;
        }

        public List<Movie> GetSpecificMovies(string title, int year) {
            MySqlDataReader moviesReader = GetMovieDataFromDatabase($"SELECT * FROM movies WHERE title LIKE '%{title}%' AND year = {year} ORDER BY averageScore DESC LIMIT 100;");
            List<Movie> movies = MapDataReaderIntoMovieList(moviesReader);

            _connection.Close();
            return movies;
        }

        public List<Movie> GetSpecificMoviesByGenre(string genre) {
            MySqlDataReader moviesReader = GetMovieDataFromDatabase("SELECT movies.* "
                                                                    + "FROM movies INNER JOIN movie_genres "
                                                                    + "ON movies.movieId = movie_genres.movieId "
                                                                    +$"WHERE movie_genres.genre = '{genre}' "
                                                                    + "ORDER BY averageScore DESC LIMIT 100;");
            List<Movie> movies = MapDataReaderIntoMovieList(moviesReader);

            _connection.Close();
            return movies;
        }


        private List<Movie> MapDataReaderIntoMovieList(MySqlDataReader moviesReader) {

            List<Movie> movies = new List<Movie>();

            while (moviesReader.Read()) {

                Movie movie = new Movie();

                movie.MovieId = moviesReader.GetInt32(0);
                movie.Title = moviesReader.GetString(1);
                movie.Year = moviesReader.GetInt16(2);
                movie.Poster = moviesReader.GetString(3);
                movie.AverageScore = moviesReader.GetFloat(9);

                movies.Add(movie);
            }

            return movies;
        }
    }
}
