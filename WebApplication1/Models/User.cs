using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Models {
    public class User {
        

        public int ID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MinLength(4)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-z]).{8,}$", 
            ErrorMessage = "Password must have minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }

        public ICollection<MovieRate> MovieRates { get; set; }
    }
}
