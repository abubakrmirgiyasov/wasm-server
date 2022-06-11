using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskOne.Models;

namespace TaskOne.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About(string sort)
        {
            using var context = new ApplicationDbContext();
            
            ViewData["FirstNameSort"] = string.IsNullOrEmpty(sort) ? "firstname" : "";
            ViewData["LastNameSort"] = string.IsNullOrEmpty(sort) ? "lastname" : "";

            return sort switch
            {
                "firstname" => View(await context.Persons.OrderByDescending(p => p.FirstName).ToListAsync()),
                "lastname" => View(await context.Persons.OrderByDescending(p => p.LastName).ToListAsync()),
                _ => View(await context.Persons.ToListAsync()),
            };
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}