using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoAppController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoAppController(AppDbContext context)
        {
            _context = context;
        }

        //GET
        public IActionResult Create() { return View(); }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(todo);
        }
    }
}
