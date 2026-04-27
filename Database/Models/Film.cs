namespace ChinaMan.Database.Models
{
    internal class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ViewedMovie> ViewedMovies { get; set; } = new();
        public List<WatchingMovie> WatchingMovies { get; set; } = new();
        public List<WantToViewMovie> WantToViewMovies { get; set; } = new();
        public List<AbandonedMovie> AbandonedMovies { get; set; } = new();
    }
}
