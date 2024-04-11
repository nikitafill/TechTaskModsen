using TechTaskModsen.Repositories;
using TechTaskModsen.Models;

namespace TechTaskModsen.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetAsyncISBN(int isbn);
        Task<Book> GetAsyncBooksByAuthor(int authorId);
    }
}
