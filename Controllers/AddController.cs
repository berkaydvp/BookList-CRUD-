using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHomework.Models;
using Microsoft.AspNetCore.Mvc;
using WebHomework.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHomework.Controllers
{
    public class AddController : Controller
    {
        MyDbContext dbContext;
        public AddController(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        // GET: /<controller>/
        public IActionResult AddUser()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                dbContext.Add(user);
                dbContext.SaveChanges();

                // Redirect to the GET action to display the updated list
                return RedirectToAction("AddBook", "Add");
            }
            catch (Exception ex)
            {
                // Log the exception details (you can use a logging framework like Serilog, NLog, etc.)
                // For simplicity, printing to the console in this example
                Console.WriteLine($"Error saving changes: {ex.Message}");

                // Optionally, you can redirect to an error page or display a user-friendly message
                return RedirectToAction("Error");
            }

            return RedirectToAction("AddBook", "Add");
        }
        public IActionResult AddBook()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            var lastUser = dbContext.Users.OrderByDescending(u => u.Id).FirstOrDefault();
            if (lastUser != null)
            {
                int userId = lastUser.Id;
                book.UserId = userId;
                try
                {
                    dbContext.Add(book);
                    dbContext.SaveChanges();

                    // Redirect to the GET action to display the updated list
                    return RedirectToAction("Index", "Books");
                }
                catch (Exception ex)
                {
                    // Log the exception details (you can use a logging framework like Serilog, NLog, etc.)
                    // For simplicity, printing to the console in this example
                    Console.WriteLine($"Error saving changes: {ex.Message}");

                    // Optionally, you can redirect to an error page or display a user-friendly message
                    return RedirectToAction("Error");
                }
                // userId'yi kullanarak gerekli işlemleri gerçekleştirin
            }
           
            return View();
        }
    }
}

