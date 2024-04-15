namespace TechTaskModsen.Models.DTOs
{
    public class AddAuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? Country { get; set; }
    }
}
