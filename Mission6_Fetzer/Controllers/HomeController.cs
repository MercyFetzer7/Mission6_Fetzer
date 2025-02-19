using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using Microsoft.EntityFrameworkCore;

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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("MovieForm", new Form());
    }

    [HttpPost]
    public IActionResult MovieForm(Form response)
    {
        if (ModelState.IsValid)
        {
            _context.Forms.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else // Invalid data
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }
    }

    public IActionResult MovieList()
    {
        // Linq query
        var  forms = _context.Forms
            .Include(x=> x.Category)
            .OrderBy(x => x.Title).ToList();
        return View(forms);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Forms
            .Single(x => x.FormId == id); // Go out and look for one record
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("MovieForm", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Form updatedInfo)
    {
        _context.Forms.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Forms
            .Single(x => x.FormId == id); // Go out and look for one record
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Form deletedInfo)
    {
        _context.Forms.Remove(deletedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
}
