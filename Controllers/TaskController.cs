using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

public class TaskController : Controller
{
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Task
    public IActionResult Index()
    {
        return View(_context.Tasks.ToList());
    }

    // GET: Task/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Task/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TodoTask task)
    {
        if (ModelState.IsValid)
        {
            _context.Add(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }

    // GET: Task/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();
        return View(task);
    }

    // POST: Task/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TodoTask task)
    {
        if (id != task.Id) return NotFound();
        
        if (ModelState.IsValid)
        {
            _context.Update(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }

    // GET: Task/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();
        return View(task);
    }

    // POST: Task/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
