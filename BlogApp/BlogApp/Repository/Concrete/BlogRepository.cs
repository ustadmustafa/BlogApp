using BlogApp.Contexts;
using BlogApp.Models;
using BlogApp.Repository.Interfaces;
using RepositoryDesignPattern.Repository.Base;

namespace BlogApp.Repository.Concrete
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogAppContext context) : base(context)
        {
        }
        public Blog Read(int id)
        {
            return table.Find(id);
        }
    }
}
