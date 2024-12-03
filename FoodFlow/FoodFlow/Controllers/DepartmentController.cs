using FoodFlow.Data;
using FoodFlow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.Department) // Department 포함
                .ToList();
            return View(employees);
        }

        [Authorize]
        public IActionResult AddDepartment()
        {
            return View();
        }

        public IActionResult Employee()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Dept_ID", "Dept_Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department model)
        {
            if (ModelState.IsValid) { 
                _context.Departments.Add(model);
                _context.SaveChanges();

                return View("Index", "Department");
            }

            return View("AddDepartment", "Department");
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Dept_ID", "Dept_Name");
            return View("Employee", "Department");
        }

        [HttpPost]
        public IActionResult CreateEmployee(string EmpName, string EmpPhone, String EmpEmail, int DeptID)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee
                {
                    Emp_Email = EmpEmail,
                    Emp_Name = EmpName,
                    Emp_Phone = EmpPhone,
                    Dept_ID = DeptID
                };

                _context.Employees.Add(emp);
                _context.SaveChanges();

                return RedirectToAction("Index", "Department");
            }

            // ModelState가 유효하지 않은 경우, ViewBag 초기화 및 모델 전달
            ViewBag.Departments = new SelectList(_context.Departments, "Dept_ID", "Dept_Name", DeptID);
            return View("Employee"); // 올바르게 Employee 모델을 전달
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
