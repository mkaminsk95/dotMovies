using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dotMovies.Data;
using dotMovies.Models;

namespace dotMovies.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly dotMovies.Data.MoviesDBContext _context;

        public IndexModel(dotMovies.Data.MoviesDBContext context)
        {
            _context = context;
        }

        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
