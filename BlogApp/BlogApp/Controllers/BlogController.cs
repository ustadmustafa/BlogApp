using BlogApp.Contexts;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        BlogAppContext _context;
        protected DbSet<Blog> table;
        protected DbSet<User> tableUser;

        public BlogController(BlogAppContext context)
        {
            _context = context;
            table = context.Set<Blog>();
        }
        public IActionResult Index()
        {
            var blogs = from b in _context.Blogs
                        join u in _context.Users on b.UserId equals u.Id
                        join c in _context.Categories on b.CategoryId equals c.Id
                        select new BlogViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Content = b.Content,
                            PublishDate = b.PublishDate,
                            AuthorName = u.UserName,
                            CategoryName = c.Name
                        };

            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View(blogs.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var userId = HttpContext.Session.GetInt32("UserId");
          
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            blog.UserId = userId.Value;  
            blog.PublishDate = DateTime.Now.ToString();

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.UpdateCategories = _context.Categories.ToList();
            var blog = table.Find(id);
            
            ViewBag.SelectedCategoryId = blog.CategoryId;

            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog blog)
        {           
            table.Update(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            table.Remove(table.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Read(int id)
        {
            var model = table.Find(id);

            return View(model);
        }



    }
}
