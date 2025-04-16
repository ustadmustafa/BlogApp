using BlogApp.Contexts;
using BlogApp.Models;
using BlogApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Repository.Base;

namespace BlogApp.Repository.Concrete
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(BlogAppContext context) : base(context)
        {
        }

        public User Login(LoginViewModel model)
        {
            var dbUser = table.FirstOrDefault(x => x.Email == model.Email);
            return dbUser;
        }
    }
}
