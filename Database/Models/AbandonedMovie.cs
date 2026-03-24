namespace ChinaMan.Database.Models
{
    internal class AbandonedMovie
    {
        public int Id { get; set; }
        public string AbandonReason { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
