using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcShoe.Data;
using System;
using System.Linq;

namespace MvcShoe.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcShoeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcShoeContext>>()))
            {
                // Look for any Shoe.
                if (context.Shoe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Shoe.AddRange(
                
                    new Shoe
                    {
                        Brand = "Adidas",
                        LaunchDate = DateTime.Parse("06-05-2022"),
                       Name = "yeezys",
                        Type = "Sports",
                        Price = 262.63M,
                        Rating = "B"
                    },

                    new Shoe
                    {
                       Brand = "Fendi",
                       LaunchDate = DateTime.Parse("11-11-2023"),
                        Name = "zebronics",
                       Type = "Sneaker",
                      Price = 164.63M,
                        Rating = "C"
                    },

                    new Shoe
                    {
                        Brand = "Reebok",
                       LaunchDate = DateTime.Parse("08-05-2021"),
                        Name = "Zaebra's",
                        Type = "High's",
                       Price = 299.63M,
                        Rating = "A"
                    },
                   new Shoe
                    {
                        Brand = "Prada",
                        LaunchDate = DateTime.Parse("01-05-2019"),
                        Name = "lGuard",
                        Type = "Safety-Shoes",
                        Price = 164.63M,
                       Rating = "D"
                   },
                   new Shoe
                    {
                       Brand = "Skechers",
                      LaunchDate = DateTime.Parse("04-09-2023"),
                       Name = "Army Boots",
                       Type = "Boots",
                        Price = 164.63M,
                       Rating = "A++"
                   },
                   new Shoe
                    {
                        Brand = "Bata",
                       LaunchDate = DateTime.Parse("10-06-2023"),
                      Name = "Asics",
                       Type = "Formals",
                        Price = 164.63M,
                       Rating = "C"
                   },
                    new Shoe
                    {
                        Brand = "Versace",
                        LaunchDate = DateTime.Parse("03-03-2009"),
                        Name = "Loafers",
                        Type = "High Sole",
                        Price = 164.63M,
                        Rating = "B"
                    },
                    new Shoe
                    {
                      Brand = "Spenco",
                       LaunchDate = DateTime.Parse("10-11-2020"),
                        Name = "Comby",
                        Type = "Loafer",
                       Price = 164.63M,
                        Rating = "A"
                    },
                   new Shoe
                    {
                       Brand = "Louis-Vuitton",
                        LaunchDate = DateTime.Parse("05-09-2015"),
                        Name = "Panda",
                        Type = "Sneaker",
                        Price = 164.63M,
                       Rating = "A"
                   },
                        new Shoe
                        {
                            Brand = "Nike",
                            LaunchDate = DateTime.Parse("10-10-2001"),
                            Name = "Air-Force-z",
                            Type = "Sneaker",
                            Price = 164.63M,
                            Rating = "A"
                        }

                );
                context.SaveChanges();
            }
        }
    }
}