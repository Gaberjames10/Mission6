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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Action" },
                new Category { CategoryID = 2, CategoryName = "Adventure" },
                new Category { CategoryID = 3, CategoryName = "Comedy" },
                new Category { CategoryID = 4, CategoryName = "Drama" },
                new Category { CategoryID = 5, CategoryName = "Fantasy" },
                new Category { CategoryID = 6, CategoryName = "Horror" },
                new Category { CategoryID = 7, CategoryName = "Musical" },
                new Category { CategoryID = 8, CategoryName = "Mystery" },
                new Category { CategoryID = 9, CategoryName = "Romance" },
                new Category { CategoryID = 10, CategoryName = "Science Fiction" },
                new Category { CategoryID = 11, CategoryName = "Sports" },
                new Category { CategoryID = 12, CategoryName = "Thriller" },
                new Category { CategoryID = 13, CategoryName = "Western" }
            );


            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Creed II",
                    Year = 2018,
                    Director = "Steven Caple Jr.",
                    Rating = "PG-13",

                },

                new MovieResponse
                {
                    MovieID = 2,
                    CategoryID = 4,
                    Title = "Good Will Hunting",
                    Year = 1997,
                    Director = "Gus Van Sant",
                    Rating = "R",

                },

                new MovieResponse
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Ford v Ferrari",
                    Year = 2019,
                    Director = "James Mangold",
                    Rating = "PG-13",

                }
                ) ;
        }
    }
}
