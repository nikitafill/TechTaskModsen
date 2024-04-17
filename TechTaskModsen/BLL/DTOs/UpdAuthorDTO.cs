using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTaskModsen.BLL.DTOs
{
    public class UpdAuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Country { get; set; }
        public List<int> BookIds { get; set; }
    }
}
