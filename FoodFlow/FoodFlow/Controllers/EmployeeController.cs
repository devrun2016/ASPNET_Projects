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

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.Employee.FirstOrDefault(e => e.Employee_ID == id);

            if (emp == null)
            {
                return View("Index", "Employee");
            }

            _context.Employee.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.Employee_ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View("EditEmployee", employee);
        }


        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = _context.Employee.FirstOrDefault(e => e.Employee_ID == model.Employee_ID);

                if (emp == null)
                {
                    return RedirectToAction("Index", "Employee"); 
                }

                // Edited Data
                emp.Employee_Name = model.Employee_Name;
                emp.Employee_DoB = model.Employee_DoB;
                emp.Employee_Gender = model.Employee_Gender;
                emp.Employee_Phone = model.Employee_Phone;
                emp.Employee_Email = model.Employee_Email;

                _context.SaveChanges();

                return RedirectToAction("Index", "Employee");
            }

            return View("EditEmployee", model);
        }

    }
}
