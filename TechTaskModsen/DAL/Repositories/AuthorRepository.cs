using TechTaskModsen.Data;
using TechTaskModsen.Interfaces;
using TechTaskModsen.Models;

namespace TechTaskModsen.Repositories
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
