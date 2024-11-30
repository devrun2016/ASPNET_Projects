using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

        [HttpPost]
        public async Task<IActionResult> SignIn(Account model)
        {
            if (ModelState.IsValid) {
                //Find User
                var acc = await _dbContext.Account.FirstOrDefaultAsync(a => a.Email == model.Email);

                var encryptedPw = new PasswordHasher<Account>();

                var result = encryptedPw.VerifyHashedPassword(acc, acc.Password, model.Password);

                if (result == PasswordVerificationResult.Success) {
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, acc.Email),
                        new Claim("AccountID", acc.Account_ID.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync("UrbanShopAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1)
                    });

                    Console.WriteLine("Succed");

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            Console.WriteLine("Fail");
            return View(model);
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("UrbanShopAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
