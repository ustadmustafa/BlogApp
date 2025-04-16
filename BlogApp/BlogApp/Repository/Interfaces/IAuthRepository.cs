using BlogApp.Models;

namespace BlogApp.Repository.Interfaces
{
    public interface IAuthRepository : IRepository<User>
    {
        User Login(LoginViewModel model);
    }
}
