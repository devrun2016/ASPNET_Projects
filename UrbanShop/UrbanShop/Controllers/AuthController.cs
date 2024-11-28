using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanShop.Data;
using UrbanShop.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace UrbanShop.Controllers
{
    public class AuthController : Controller
    {
        //AppDbContext
        private readonly AppDbContext _context;

        //AppDbContext Constructor
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check Account
                var existingAccount = await _context.Account.FirstOrDefaultAsync(a => a.User_Account == model.User_Account);

                //Display Error when user account already in DB
                if (existingAccount != null)
                {
                    ModelState.AddModelError("User_Account", "This account already exists.");
                }

                //Check Email
                var existingEmail = await _context.Customers.FirstOrDefaultAsync(c => c.Customer_Email == model.Customer_Email);

                //Display error when user email already in DB
                if (existingEmail != null)
                {
                    ModelState.AddModelError("Customer_Email", "This email is already registered.");
                }

                var account = new Account
                {
                    User_Account = model.User_Account,
                    User_Password = model.User_Password
                };

                var customer = new Customer
                {
                    Customer_Name = model.Customer_Name,
                    Customer_Email = model.Customer_Email,
                    Customer_Phone = model.Customer_Phone,
                };

                //Saving Account Data To DB
                await _context.Account.AddAsync(account);
                await _context.SaveChangesAsync();

                //Add Account ID From Account -> Customer Table Account_ID(FK)
                customer.Account_ID = account.Account_ID;

                //Saving Customer Data To DB
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                //After finished sign up set session
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.User_Account),
                    new Claim("AccountId", account.Account_ID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync("UrbanShopAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                });

                return RedirectToAction("Index", "Home");
            }

            //Redirect view to home
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("UrbanShopAuth");
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find user by account
                var account = await _context.Account.FirstOrDefaultAsync(a => a.User_Account == model.User_Account);

                if (account != null && account.User_Password == model.Password)
                {
                    // Set session
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.User_Account),
                new Claim("AccountId", account.Account_ID.ToString())
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync("UrbanShopAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1)
                    });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

    }
}
