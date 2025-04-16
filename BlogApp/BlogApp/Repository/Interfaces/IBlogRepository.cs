using BlogApp.Models;

namespace BlogApp.Repository.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog Read(int id);
    }
}
