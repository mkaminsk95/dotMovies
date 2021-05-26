using dotMovies.Data;
using dotMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Services {
    public class UsersService {

        private MoviesDBContext _context;

        public UsersService(MoviesDBContext moviesDBContext) {
            _context = moviesDBContext;

        }

        public bool CheckCredentials(User credentials) {

            if (_context.Users.Any(user => (user.Login == credentials.Login
                                 && user.Password == credentials.Password))) {
                return true;
            } else
                return false;
        }

        public bool AddNewUser(User newUser) {

            if (_context.Users.Any(user => user.Login == newUser.Login)) {
                return false;
            } else {
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return true;
            }

        }

        //public async Task<IActionResult> OnPostAsync() {


        //    _context.Users.Add(User);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
