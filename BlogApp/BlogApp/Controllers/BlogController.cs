﻿using BlogApp.Contexts;
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
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;
            var blogAuthor = HttpContext.Session.GetString("UserName");
            ViewBag.BlogAuthor = blogAuthor;
            var blogs = table.ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
          
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth"); // Login'e yönlendir
            }
            ViewBag.Author = HttpContext.Session.GetString("UserName");
            blog.UserId = userId.Value;
            blog.UserName = ViewBag.Author;
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


        public IActionResult Read(int id)
        {
            var model = table.Find(id);

            return View(model);
        }



    }
}
