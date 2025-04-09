using System;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        
        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
        
        // GET: Tasks
        public IActionResult Index()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }
        
        // GET: Tasks/Details/5
        public IActionResult Details(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            
            return View(task);
        }
        
        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _taskService.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        
        // GET: Tasks/Edit/5
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            
            return View(task);
        }
        
        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskItem task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        
        // GET: Tasks/Delete/5
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            
            return View(task);
        }
        
        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }
        
        // POST: Tasks/ToggleComplete/5
        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            _taskService.ToggleTaskCompletion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}