using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Titanic",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Breaking Bad",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Drama",
                    Rating = "R",
                    Price = 8.99M

                },
                new Movie
                {
                    Title = "Tomb Raider",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                },
                 new Movie
                 {
                     Title = "NInja Turtle",
                     ReleaseDate = DateTime.Parse("1959-4-15"),
                     Genre = "Action",
                     Rating = "S",
                     Price = 3.99M
                 }

            );
            context.SaveChanges();
        }
    }
}