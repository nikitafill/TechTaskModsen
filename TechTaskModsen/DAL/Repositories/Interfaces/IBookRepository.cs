using TechTaskModsen.Repositories;
using TechTaskModsen.Models;

namespace TechTaskModsen.DAL.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetAsyncISBN(int isbn);
        Task<List<Book>> GetAsyncBooksByAuthor(int authorId);
    }
}
