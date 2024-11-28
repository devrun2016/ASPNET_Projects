using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanShop.Data;
using UrbanShop.Models;
using System.Threading.Tasks;

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

            //Redirect view to home
            return RedirectToAction("Index", "Home");
        }
    }
}
