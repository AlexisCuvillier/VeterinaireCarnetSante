using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser> 
                {
                    new AppUser{DisplayName = "Bob", UserName = "bob", Email="bob@test.com"},
                    new AppUser{DisplayName = "Andy", UserName = "andy", Email="tom@test.com"},
                    new AppUser{DisplayName = "Jhon", UserName = "jhon", Email="jin@test.com"},
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if (context.Pets.Any()) return;
            {
                var pets = new List<Pet>
                {
                    new Pet
                    {
                        Name = "Falcor",
                        Age = 5,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-1825),
                        NextDateVaccin = DateTime.UtcNow.AddDays(3)
                    },
                    new Pet
                    {
                        Name = "Bouboule",
                        Age = 7,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-2555),
                        NextDateVaccin = DateTime.UtcNow.AddDays(24)
                    },
                    new Pet
                    {
                        Name = "Wayne",
                        Age = 8,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-2920),
                        NextDateVaccin = DateTime.UtcNow.AddDays(12)
                    }
                };
                await context.Pets.AddRangeAsync(pets);
                await context.SaveChangesAsync();
            }

            if(context.Vaccins.Any()) return;
            {
                var vaccins = new List<Vaccin>
                {
                    new Vaccin
                    {
                       Name = "CHLRP"
                    },
                    new Vaccin
                    {
                        Name = "Parvovirose"
                    },
                    new Vaccin
                    {
                         Name = "Hépatite Canine"
                    },
                    new Vaccin
                    {
                        Name = "Leptospirose"
                    },
                    new Vaccin
                    {
                        Name = "Rage "
                    },
                };
                await context.Vaccins.AddRangeAsync(vaccins);
                await context.SaveChangesAsync();
            }

            if(context.Visits.Any()) return;
            {
                var historicalVisits = new List<Visit>
                {
                    new Visit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-75),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    },
                    new Visit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-80),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    },
                    new Visit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-30),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    }
                };
                await context.Visits.AddRangeAsync(historicalVisits);
                await context.SaveChangesAsync();
            }

            if(!context.Masters.Any())
            {
                var masters = new List<Master>
                {
                    new Master 
                    {
                        NamePrename = "Bob LeBricoleur",
                        Adress = "1 Rue de la poupee qui tousse",
                        Mail = "bob@test.com"
                    },
                    new Master 
                    {
                        NamePrename = "Andy Cape",
                        Adress = "3 Rue de la poupee qui tousse",
                        Mail = "andy@test.com"
                    },new Master 
                    {
                        NamePrename = "Jhon Doe",
                        Adress = "1 Rue de la poupee qui tousse",
                        Mail = "jhon@test.com"
                    },
                };
            }

        }
    }
}