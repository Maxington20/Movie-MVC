using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new MvcMovieContext(
				serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
			{
				if (context.Movie.Any())
				{
					return; //DB has been seeded
				}

				context.Movie.AddRange(
					new Movie
					{
						Title = "When Harry Met Sally",
						ReleaseDate = DateTime.Parse("1989"),
						Genre = "Romantic Comedy",
						Pice = 7.99M,
						Rating = "R"
					},

					new Movie
					{
						Title = "Ghostbusters",
						ReleaseDate = DateTime.Parse("1984"),
						Genre = "Comedy",
						Pice = 8.99M,
						Rating = "R"
					},

					new Movie
					{
						Title = "Ghostbusters 2",
						ReleaseDate = DateTime.Parse("1986"),
						Genre = "Comedy",
						Pice = 9.99M,
						Rating = "R"
					},

					new Movie
					{
						Title = "Star Wars",
						ReleaseDate = DateTime.Parse("1977"),
						Genre = "Adventure",
						Pice = 10.99M,
						Rating = "PG"
					}
				);
				context.SaveChanges();
			}
		}
    }
}
