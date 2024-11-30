using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UrbanShop.Controllers
{
    public class BaseController : Controller
    {
        //DB
        private readonly AppDbContext _dbContext;

        public BaseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

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
        }
    }
}
