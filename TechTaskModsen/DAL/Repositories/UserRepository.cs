using TechTaskModsen.DAL.Repositories.Interfaces;
using TechTaskModsen.DAL.Data;
using TechTaskModsen.DAL.Models;

namespace TechTaskModsen.DAL.Repositories
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
