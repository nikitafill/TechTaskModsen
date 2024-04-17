using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTaskModsen.BLL.DTOs
{
    public class UpdBookDTO
    {
        public int ISBN { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "bytea")]
        public byte[]? ImageData { get; set; }

        public int AuthorId { get; set; }
    }
}
