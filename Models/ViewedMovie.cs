namespace ChinaMan.Models
{
    public class ViewedMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ViewedDate { get; set; }
        public int Rating { get; set; }
    }
}
