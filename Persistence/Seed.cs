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
                        DateOfBirth = DateTime.Now
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
                        LastDate = DateTime.Now,
                        NextDate =DateTime.Now
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
                        
                    }
                };
                await context.historicalVisits.AddRangeAsync(historicalVisits);
                await context.SaveChangesAsync();
            }
        }
    }
}