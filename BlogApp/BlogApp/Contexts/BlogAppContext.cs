using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Contexts
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=BlogAppDatabase; integrated security=true;");
        }
    }
}
