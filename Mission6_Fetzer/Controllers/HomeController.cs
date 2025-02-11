using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
   private MovieFormContext _context;

   public HomeController(MovieFormContext temp)
   {
       _context = temp;
   }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GettoKnow()
    {
        return View();
    }
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Form response)
    {
        _context.Forms.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
    
}
