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

        public BlogController(BlogAppContext context)
        {
            _context = context;
            table = context.Set<Blog>();
        }
        public IActionResult Index()
        {
            var blogs = table.ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            table.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var blog = table.Find(id);

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

    }
}
