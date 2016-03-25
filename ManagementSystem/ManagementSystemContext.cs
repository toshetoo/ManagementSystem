using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementSystem
{
    public class ManagementSystemContext : DbContext
    {
        public ManagementSystemContext() : base("ManagementSystemDB") { }
      
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}