using TechTaskModsen.Models;

namespace TechTaskModsen.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Registration(User user);
        Task<User> Login(User user);
    }
}
