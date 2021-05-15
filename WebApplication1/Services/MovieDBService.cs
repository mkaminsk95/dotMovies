using dotMovies.Models;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Services {
    public class MovieDBService {

        private string connectionString = "server=localhost;user id=root;database=dotmoviesdb;allowuservariables=True;password=movieDBpassword";

        public MovieDBService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public List<Movie> GetMovies() {

            List<Movie> movies = new List<Movie>();
            

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM movies ORDER BY averageScore DESC LIMIT 100";

            MySqlDataReader moviesReader = command.ExecuteReader();

            while(moviesReader.Read()) {

                Movie movie = new Movie();

                movie.Id = moviesReader.GetInt32(0);
                movie.Title = moviesReader.GetString(1);
                movie.Year = moviesReader.GetInt16(2);
                movie.Poster = moviesReader.GetString(3);
                movie.Director = moviesReader.GetString(4);
                //movie.Length = moviesReader.GetTimeSpan(5).ToString();

                movies.Add(movie);
            }

            connection.Close();

            return movies;
        }
    }
}
