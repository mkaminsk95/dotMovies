using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotMovies.Models;

namespace dotMovies.Data
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext (DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRate> MovieRates { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().ToTable("UsersManager");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<MovieRate>().ToTable("MovieRate");
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");

            modelBuilder.Entity<MovieGenre>().HasKey(nameof(MovieGenre.Genre), nameof(MovieGenre.MovieID));
        }
    }
}
