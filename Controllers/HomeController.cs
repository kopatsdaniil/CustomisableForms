using CustomisableForms.Data;
using CustomisableForms.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CustomisableForms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            var forms = from f in _context.Forms
                        select f;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                forms = forms.Where(f => f.Title.Contains(searchTerm) || f.Description.Contains(searchTerm));
            }

            return View(forms.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
