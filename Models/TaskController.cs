using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<Models.Task> _tasks = new List<Models.Task>();
        private int _nextId = 1;
        
        public TaskService()
        {
            // Add some sample tasks
            AddTask(new Models.Task { 
                Title = "Buy groceries", 
                Description = "Milk, eggs, bread, and vegetables", 
                DueDate = DateTime.Now.AddDays(1),
                Priority = TaskPriority.Medium
            });
            
            AddTask(new Models.Task { 
                Title = "Complete project report", 
                Description = "Finish quarterly project summary", 
                DueDate = DateTime.Now.AddDays(3),
                Priority = TaskPriority.High
            });
            
            AddTask(new Models.Task { 
                Title = "Call customer support", 
                Description = "Regarding invoice #12345", 
                DueDate = DateTime.Now.AddDays(2),
                Priority = TaskPriority.Low
            });
        }
        
        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasks.OrderBy(t => t.IsCompleted)
                .ThenBy(t => (int)t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
        }
        
        public Models.Task GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        
        public void AddTask(Models.Task task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }
        
        public void UpdateTask(Models.Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.IsCompleted = task.IsCompleted;
                existingTask.Priority = task.Priority;
            }
        }
        
        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
        
        public void ToggleTaskCompletion(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
            }
        }
    }
}
