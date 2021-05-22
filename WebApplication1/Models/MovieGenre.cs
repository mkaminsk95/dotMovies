using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Models {
    public class MovieGenre {

        [Key]
        public string Genre { get; set; }
        public int MovieID { get; set; }

        public Movie Movie { get; set; }
    }
}
