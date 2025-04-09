using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Task Title")]
        public string Title { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }
        
        [Display(Name = "Priority")]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    
    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }
}