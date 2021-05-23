using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Poster { get; set; }
        public string Director { get; set; }
        public string Screenplay { get; set; }
        public TimeSpan Runtime { get; set; }
        public uint Budget { get; set; } 
        public uint Revenue { get; set; }
        [Range(1, 10)]
        public float AverageScore { get; set; }

        public ICollection<MovieGenre> Genres { get; set; }
        public ICollection<MovieRate> MovieRates { get; set; }

    }
}
