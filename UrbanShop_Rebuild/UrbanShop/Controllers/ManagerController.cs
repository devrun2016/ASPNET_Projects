using Microsoft.AspNetCore.Mvc;

namespace UrbanShop.Controllers
{
    public class ManagerController : Controller
    {

        private readonly AppDbContext _dbContext;

        public ManagerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
