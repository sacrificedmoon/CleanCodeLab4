using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BugtrackerBackend.Models;

namespace BugtrackerBackend.Data
{
    public class BugtrackerContext : DbContext
    {
        public BugtrackerContext (DbContextOptions<BugtrackerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bug> Bug { get; set; }
    }
}
