using BlogApp.Contexts;
using BlogApp.Models;
using BlogApp.Repository.Interfaces;
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
        IRepository<Blog> _blogRepository;
        IBlogRepository _blogRepo;

        public BlogController(BlogAppContext context, IRepository<Blog> blogRepository, IBlogRepository blogRepo)
        {
            _context = context;
            table = context.Set<Blog>();
            _blogRepository = blogRepository;
            _blogRepo = blogRepo;
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
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(blog);
            }
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            blog.UserId = userId.Value;  
            blog.PublishDate = DateTime.Now.ToString();


            _blogRepository.Create(blog);
            //_context.Blogs.Add(blog);
            //_context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var blog = table.Find(id);
            
            ViewBag.SelectedCategoryId = blog.CategoryId;

            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(blog);
            }
            _blogRepository.Edit(blog);
            //table.Update(blog);
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _blogRepository.Delete(id);
            //table.Remove(table.Find(id));
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Read(int id)
        {
            var model = _blogRepo.Read(id);

            return View(model);
        }



    }
}
