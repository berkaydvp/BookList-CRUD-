using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebHomework.Context;
using WebHomework.Models;

namespace WebHomework.Controllers;

public class HomeController : Controller
{
   

    public IActionResult Index()
    { 
        return View();
    }
   
}

