using BlogApp.Contexts;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Validasyon hatalarıyla birlikte view'a geri dön
            }

            var dbUser = _context.Users.FirstOrDefault(x => x.Email == model.Email);

            if (dbUser == null || dbUser.Password != model.Password)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı!");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", dbUser.Id);
            HttpContext.Session.SetString("UserName", dbUser.UserName);

            return RedirectToAction("Index", "Blog");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel); 
            }

            var user = table.FirstOrDefault(x => x.Email == registerViewModel.Email);
            if(user != null)
            {
                return BadRequest();
            }
            User usertoadd = new User
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };

            table.Add(usertoadd);
            _context.SaveChanges();


            var dbUser = _context.Users.FirstOrDefault(x => x.Email == registerViewModel.Email);

            HttpContext.Session.SetInt32("UserId", dbUser.Id);
            HttpContext.Session.SetString("UserName", registerViewModel.UserName);


            return RedirectToAction("Index", "Blog");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult GuestAccess()
        {
            HttpContext.Session.Clear();
            ViewBag.GuestAccess = HttpContext.Session.GetInt32("UserId");
            return RedirectToAction("Index","Blog");
        }






    }
}
