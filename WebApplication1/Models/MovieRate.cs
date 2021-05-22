using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Models {
    public class MovieRate {

        public int ID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int Rate { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
