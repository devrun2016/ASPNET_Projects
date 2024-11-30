using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                //Compare Email Address From DB
                var emailCheck = await _dbContext.Account.FirstOrDefaultAsync(a => a.Email == model.ac_email);

                if (emailCheck != null) {
                    TempData["ErrorMessage"] = "This email address is already in use.";
                    return View();
                }

                //Hashing password
                var encryptedPw = new PasswordHasher<Account>();

                var account = new Account
                {
                    Email = model.ac_email,
                    Password = encryptedPw.HashPassword(null, model.ac_password)
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

            TempData["ErrorMessage"] = "Please check the form for errors.";
            return RedirectToAction("SignUp", "Auth");
        }
    }
}
