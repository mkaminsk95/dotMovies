using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string[] Genre { get; set; }
        public string Length { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Movie>(this);
        
    }
}
