namespace ChinaMan.Database.Models
{
    internal class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ViewedMovie> Views { get; set; } = new();
    }
}
