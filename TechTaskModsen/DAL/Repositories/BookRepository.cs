using Microsoft.EntityFrameworkCore;
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
        public async Task<Book> GetAsyncISBN(int isbn)
        {
            return await _context.Set<Book>().FirstOrDefaultAsync(b => b.ISBN == isbn);
        }
        public async Task<List<Book>> GetAsyncBooksByAuthor(int authorId)
        {
            return await _context.Set<Book>()
                .Where(book => book.Author.Id == authorId)
                .ToListAsync();
        }
    }
}
