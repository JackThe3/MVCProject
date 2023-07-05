using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCProject.Data;
using MVCProject.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MVCProjectContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MVCProjectContext>>()))
        {
            // Look for any movies.
            if (context.Plan.Any())
            {
                return;   // DB has been seeded
            }
            context.Plan.AddRange(
                new Plan
                {
                    Name = "Adamkovci",
                    Owner = "Adamková Denisa",
                    CreatedAt = DateTime.Parse("2023-1-4"),
                    UpdatedAt = DateTime.Parse("2023-6-12"),
                    Status = true,
                    UpdatedBy = "Olivia Rhye"
                },
                new Plan
                {
                    Name = "Mitchell",
                    Owner = "Bob Mitchel",
                    CreatedAt = DateTime.Parse("2023-1-4"),
                    UpdatedAt = DateTime.Parse("2023-5-12"),
                    Status = true,
                    UpdatedBy = "Phonex Baker"
                },
                new Plan
                {
                    Name = "Rutherford",
                    Owner = "Luna Rutherford",
                    CreatedAt = DateTime.Parse("2023-1-2"),
                    UpdatedAt = DateTime.Parse("2023-1-2"),
                    Status = false,
                    UpdatedBy = "Lena Steiner"
                },
                new Plan
                {
                    Name = "Bahringer",
                    Owner = "Demi Bahringer",
                    CreatedAt = DateTime.Parse("2023-1-6"),
                    UpdatedAt = DateTime.Parse("2023-1-6"),
                    Status = true,
                    UpdatedBy = "Demi Wikinson"
                },
                new Plan
                {
                    Name = "Grady",
                    Owner = "Candice Grady",
                    CreatedAt = DateTime.Parse("2023-1-8"),
                    UpdatedAt = DateTime.Parse("2023-1-8"),
                    Status = true,
                    UpdatedBy = "Candice Wu"
                },
                new Plan
                {
                    Name = "Adams",
                    Owner = "Natali Adams",
                    CreatedAt = DateTime.Parse("2023-1-6"),
                    UpdatedAt = DateTime.Parse("2023-1-6"),
                    Status = true,
                    UpdatedBy = "Natali Craig"
                }
            );
            context.SaveChanges();
        }
    }
}