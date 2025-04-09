using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextId = 1;
        
        public TaskService()
        {
            
            AddTask(new TaskItem { 
                Title = "Complete project report", 
                Description = "Finish quarterly project summary", 
                DueDate = DateTime.Now.AddDays(3),
                Priority = TaskPriority.High
            });
            
            AddTask(new TaskItem { 
                Title = "Call customer support", 
                Description = "Regarding invoice #12345", 
                DueDate = DateTime.Now.AddDays(2),
                Priority = TaskPriority.Low
            });
        }
        
        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _tasks.OrderBy(t => t.IsCompleted)
                .ThenBy(t => (int)t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
        }
        
        public TaskItem GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        
        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }
        
        public void UpdateTask(TaskItem task)
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