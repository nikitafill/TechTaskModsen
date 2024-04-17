using TechTaskModsen.DAL.Models;

namespace TechTaskModsen.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Registration(User user);
        Task<User> Login(User user);
    }
}
