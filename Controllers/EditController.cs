using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHomework.Context;
using WebHomework.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHomework.Controllers
{
    public class EditController : Controller
    {
        MyDbContext dbContext;
        public EditController(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        // GET: /<controller>/

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index( Book book, int bookId = -1)
        {
            var editedBook = dbContext.Books.Find(book.Id);
            if (bookId != -1)
            {
                var selectedBook = dbContext.Books.Find(bookId);
                selectedBook.Id = bookId;
                ViewBag.book = selectedBook;
            }     
            if(book.Author != null)
            {
                editedBook.Name = book.Name;
                editedBook.CategoryName = book.CategoryName;
                editedBook.isRead = book.isRead;
                editedBook.Author = book.Author;
                dbContext.SaveChanges();
                return RedirectToAction("index", "books");
            }

            return View();
        }

        public IActionResult delete(int bookId)
        {
            var editedBook = dbContext.Books.Find(bookId);
            dbContext.Remove(editedBook);
            dbContext.SaveChanges();
            return RedirectToAction("index","books");
        }

    }
}

