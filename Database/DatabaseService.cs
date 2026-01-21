using ChinaMan.Models;

namespace ChinaMan.Database
{
    static class DatabaseService
    {
        public static void SaveViewedMovie(ApplicationContext dbContext, ViewedMovie movie)
        {
            dbContext.Add(movie);
            dbContext.SaveChanges();
        }
    }
}
