using ChinaMan.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ChinaMan.Database
{
    internal class ApplicationContext : DbContext
    {
        internal DbSet<Film> Films { get; set; } = null!;
        internal DbSet<ViewedMovie> ViewedMovies { get; set; } = null!;
        internal DbSet<WatchingMovie> WatchingMovies { get; set; } = null!;
        internal DbSet<WantToViewMovie> WantToViewMovies { get; set; } = null!;
        internal DbSet<AbandonedMovie> AbandonedMovies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=chinaman.db;");
        }
    }
}
