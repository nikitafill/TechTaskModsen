using TechTaskModsen.Data;
using TechTaskModsen.Interfaces;
using TechTaskModsen.Models;
namespace TechTaskModsen.Repositories
{
    public class BookRepository: GenericRepository<Book> , IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
