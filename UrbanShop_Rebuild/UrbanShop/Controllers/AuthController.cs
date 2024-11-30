using Microsoft.AspNetCore.Mvc;
using UrbanShop.Models;

namespace UrbanShop.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AccountCustomerViewModel model)
        {
            if (ModelState.IsValid) {
                var account = new Account
                {
                    Email = model.ac_email,
                    Password = model.ac_password
                };

                _dbContext.Add(account);
                _dbContext.SaveChanges();

                var customer = new Customer
                {
                    Customer_Name = model.ac_name,
                    Customer_Phone = model.ac_phone,
                    Account_ID = account.Account_ID
                };

                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
