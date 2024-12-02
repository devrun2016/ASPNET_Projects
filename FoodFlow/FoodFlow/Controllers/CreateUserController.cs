using FoodFlow.Data;
using FoodFlow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodFlow.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly AppDbContext _context;

        public CreateUserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string email, string password, string fullName, string phoneNumber)
        {
            if (ModelState.IsValid) {
                //Email checker
                bool emailChecker = _context.Account.Any(a => a.Account_Email == email);

                if (emailChecker)
                {
                    ModelState.AddModelError("Email", "This email is already in use.");
                    return View("Index");
                } else
                {

                    var passwordHasher = new PasswordHasher<Account>();

                    var account = new Account
                    {
                        Account_Email = email,
                        Account_Password = "temp"
                    };

                    account.Account_Password = passwordHasher.HashPassword(account, password);

                    var user = new User
                    {
                        User_FullName = fullName,
                        User_Phone = phoneNumber,
                        Account = account
                    };

                    _context.Account.Add(account);
                    _context.Users.Add(user);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Dashboard");
                }
            }

            return View("Index");
        }
    }
}
