using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pet> Pets {get; set;}
        public DbSet<historicalVisit> historicalVisits { get; set; }
        public DbSet<Vaccin> Vaccins { get; set; }
        public DbSet<User> Users { get; set; }

    }
}