using ChinaMan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChinaMan.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ViewedMovie> viewedMovies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.db;");
        }
    }
}
