using TechTaskModsen.Data;
using TechTaskModsen.Interfaces;
using TechTaskModsen.Models;

namespace TechTaskModsen.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
