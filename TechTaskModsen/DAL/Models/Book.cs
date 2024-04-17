using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTaskModsen.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime? IssueTime   { get; set; }
        public DateTime? ReturnTime { get; set; }

        [Column(TypeName = "bytea")]
        public byte[]? ImageData { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
