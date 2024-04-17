using TechTaskModsen.DAL.Repositories;
using TechTaskModsen.DAL.Models;

namespace TechTaskModsen.DAL.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetAsyncISBN(int isbn);
        Task<List<Book>> GetAsyncBooksByAuthor(int authorId);
    }
}
