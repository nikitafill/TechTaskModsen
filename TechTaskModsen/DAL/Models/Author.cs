namespace TechTaskModsen.DAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Country { get; set; }
        public List<Book> Books { get; set; }
    }
}
