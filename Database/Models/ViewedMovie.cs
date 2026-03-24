namespace ChinaMan.Database.Models
{
    internal class ViewedMovie
    {
        public int Id { get; set; }
        public DateTime ViewedDate { get; set; } = DateTime.Now;
        public int Rating { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
