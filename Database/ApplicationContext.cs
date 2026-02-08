using ChinaMan.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ChinaMan.Database
{
    internal class ApplicationContext : DbContext
    {
        internal DbSet<Film> Films { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.db;");
        }
    }
}
