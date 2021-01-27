using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class WhoAreWeContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString: @"SERVER=127.0.0.1;PORT=3306 ;DATABASE=WhoAreWe;UID=root;PASSWORD=xxxxxxx;");
        }

        public DbSet<Client> Projects { get; set; }
    }
}
