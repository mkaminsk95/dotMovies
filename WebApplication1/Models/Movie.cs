using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Poster { get; set; }
        public string Director { get; set; }
        public string Screenplay { get; set; }
        public TimeSpan Runtime { get; set; }
        public int Budget { get; set; }
        public int Revenue { get; set; }
        public float AverageScore { get; set; }
        public string[] Genre { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Movie>(this);
        
    }
}
