using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Master> Masters {get; set; }
        public DbSet<Pet> Pets {get; set;}
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Vaccin> Vaccins { get; set; }
   




        

    }
}