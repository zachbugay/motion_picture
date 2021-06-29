using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using server.Models;

namespace server.Data {
    public class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>())) {
                // Look for any movies.
                if (context.MotionPictures.Any()) {
                    return;   // DB has been seeded
                }

                context.MotionPictures.AddRange(
                    new MotionPicture {
                        Name = "Name of the Movie",
                        Description = "An apt description for the movie.",
                        ReleaseYear = 2021
                    },
                    new MotionPicture {
                        Name = "Name of Another Movie",
                        Description = "An apt description for the other movie.",
                        ReleaseYear = 2020
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
