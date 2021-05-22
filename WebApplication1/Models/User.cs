using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Models {
    public class User {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<MovieRate> MovieRates { get; set; }
    }
}
