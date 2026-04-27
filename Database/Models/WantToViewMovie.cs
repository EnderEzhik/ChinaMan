namespace ChinaMan.Database.Models
{
    internal class WantToViewMovie
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Film Film { get; set; }
    }
}
