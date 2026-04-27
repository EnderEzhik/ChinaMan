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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().Property(f => f.CreatedAt).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<Film>().HasData(
                new Film() { Id=1, Title="Первый тестовый фильм"},
                new Film() { Id=2, Title="Аватар: Легенда об Аанге"},
                new Film() { Id=3, Title="Трансформеры: Прайм"},
                new Film() { Id=4, Title="Шрек"},
                new Film() { Id=5, Title="Гравити фолз"},
                new Film() { Id=6, Title="Рик и морти"},
                new Film() { Id=7, Title="Алиса знает что делать"},
                new Film() { Id=8, Title= "Очень длинное название часть вторая: продолжение длинного названия" }
            );

            modelBuilder.Entity<ViewedMovie>().Property(f => f.CreatedAt).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<ViewedMovie>().Property(f => f.ViewedDate).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<ViewedMovie>().HasData(
                new ViewedMovie() { Id=1, FilmId=1, Rating=7},
                new ViewedMovie() { Id=2, FilmId=2, Rating=10},
                new ViewedMovie() { Id=3, FilmId=2, Rating=10}
            );

            modelBuilder.Entity<WatchingMovie>().Property(f => f.CreatedAt).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<WatchingMovie>().HasData(
                new WatchingMovie() { Id=1, FilmId=3},
                new WatchingMovie() { Id=2, FilmId=5}
            );

            modelBuilder.Entity<WantToViewMovie>().Property(f => f.CreatedAt).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<WantToViewMovie>().HasData(
                new WantToViewMovie() { Id = 1, FilmId = 6 },
                new WantToViewMovie() { Id = 2, FilmId = 7 }
            );

            modelBuilder.Entity<AbandonedMovie>().Property(f => f.CreatedAt).HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<AbandonedMovie>().HasData(
                new AbandonedMovie() { Id = 1, FilmId = 4, AbandonReason="Не фанат шрека" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
