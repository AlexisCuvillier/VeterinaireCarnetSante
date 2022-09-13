using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Pets.Any()) return;
            {
                var pets = new List<Pet>
                {
                    new Pet
                    {
                        Name = "Falcor",
                        Age = 5,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-1825)
                    },
                    new Pet
                    {
                        Name = "Bouboule",
                        Age = 7,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-2555)
                    },
                    new Pet
                    {
                        Name = "Wayne",
                        Age = 8,
                        DateOfBirth =  DateTime.UtcNow.AddDays(-2920)
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
                        LastDate =  DateTime.UtcNow.AddDays(-365),
                        NextDate = DateTime.UtcNow.AddDays(18)
                    },
                    new Vaccin
                    {
                        LastDate =  DateTime.UtcNow.AddDays(-380),
                        NextDate =  DateTime.UtcNow.AddDays(5) 
                    },
                    new Vaccin
                    {
                        LastDate =  DateTime.UtcNow.AddDays(-400),
                        NextDate =  DateTime.UtcNow.AddDays(12)
                    }
                };
                await context.Vaccins.AddRangeAsync(vaccins);
                await context.SaveChangesAsync();
            }

            if(context.historicalVisits.Any()) return;
            {
                var historicalVisits = new List<historicalVisit>
                {
                    new historicalVisit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-75),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    },
                    new historicalVisit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-80),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    },
                    new historicalVisit
                    {
                        LastVisit = DateTime.UtcNow.AddDays(-30),
                        NextVisit =  DateTime.UtcNow.AddDays(45)
                        
                    }
                };
                await context.historicalVisits.AddRangeAsync(historicalVisits);
                await context.SaveChangesAsync();
            }
        }
    }
}