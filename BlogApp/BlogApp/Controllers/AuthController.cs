using BlogApp.Contexts;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;

namespace BlogApp.Controllers
{
    public class AuthController : Controller
    {
        BlogAppContext _context;
        protected DbSet<User> table;

        public AuthController(BlogAppContext context)
        {
            _context = context;
            table = context.Set<User>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = table.FirstOrDefault(x => x.Email == email);
            if (user == null || user.Password != password)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Blog");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            var user = table.FirstOrDefault(x => x.Email == email);
            if(user != null)
            {
                return BadRequest();
            }
            User usertoadd = new User
            {
                UserName = username,
                Email = email,
                Password = password
            };

            table.Add(usertoadd);
            _context.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }



    }
}
