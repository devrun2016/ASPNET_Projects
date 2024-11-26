using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CreateController : Controller
    {
        //AppDbContext
        private readonly AppDbContext _context;

        //AppDbContext Constructor
        public CreateController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Add(item);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(item);
        }
    }
}
