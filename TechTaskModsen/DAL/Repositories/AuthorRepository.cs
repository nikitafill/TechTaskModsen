using TechTaskModsen.DAL.Repositories.Interfaces;
using TechTaskModsen.DAL.Data;
using TechTaskModsen.DAL.Models;

namespace TechTaskModsen.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
