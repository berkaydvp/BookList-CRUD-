using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHomework.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHomework.Controllers
{
    public class BooksController : Controller
    {
        MyDbContext dbContext;
        public BooksController(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            var books = dbContext.Books.ToList();
            ViewBag.users = users;
            ViewBag.books = books;
            return View();
        }
    }
}

