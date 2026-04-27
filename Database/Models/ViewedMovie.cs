namespace ChinaMan.Database.Models
{
    internal class ViewedMovie
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ViewedDate { get; set; }
        public int Rating { get; set; }

        public Film Film { get; set; }
    }
}
