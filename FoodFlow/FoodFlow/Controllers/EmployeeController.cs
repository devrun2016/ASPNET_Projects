using FoodFlow.Data;
using FoodFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFlow.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context) 
        {
            _context = context;
        }



        //Employee Dashboard
        public IActionResult Index()
        {
            var employees = _context.Employee.ToList();
            return View(employees);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee model)
        {
            if (ModelState.IsValid) { 
                _context.Employee.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Employee");
            }

            return View("AddEmployee", "Employee");
        }

    }
}
