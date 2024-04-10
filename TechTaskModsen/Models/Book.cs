namespace TechTaskModsen.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime IssueTime   { get; set; }
        public DateTime ReturnTime { get; set; }

        public Author Author { get; set; }

    }
}
