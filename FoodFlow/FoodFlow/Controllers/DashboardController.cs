using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodFlow.Controllers
{
    public class DashboardController : Controller
    {
        public string GetCurrentUserEmail()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        [Authorize]
        public IActionResult Index()
        {
            //Save Email To ViewBag
            var email = GetCurrentUserEmail();
            ViewBag.UserEmail = email; 

            return View();
        }
    }
}
