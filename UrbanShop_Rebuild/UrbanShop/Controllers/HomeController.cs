using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrbanShop.Models;

namespace UrbanShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;


        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var email = User.Identity?.Name;
            if (!string.IsNullOrEmpty(email))
            {
                var isManager = _dbContext.Manger.Any(m => m.email == email);
                ViewBag.IsManager = isManager;
            }
            else
            {
                ViewBag.IsManager = false;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
