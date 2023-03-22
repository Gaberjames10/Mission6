using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        { }
        public DbSet<MovieResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    Category = "Action/Sport",
                    Title = "Creed II",
                    Year = 2018,
                    Director = "Steven Caple Jr.",
                    Rating = "PG-13",

                },

                new MovieResponse
                {
                    MovieID = 2,
                    Category = "Drama",
                    Title = "Good Will Hunting",
                    Year = 1997,
                    Director = "Gus Van Sant",
                    Rating = "R",

                },

                new MovieResponse
                {
                    MovieID = 3,
                    Category = "Action",
                    Title = "Ford v Ferrari",
                    Year = 2019,
                    Director = "James Mangold",
                    Rating = "PG-13",

                }
                ) ;
        }
    }
}
