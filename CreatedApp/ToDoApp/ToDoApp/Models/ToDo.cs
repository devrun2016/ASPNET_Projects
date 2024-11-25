using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Task name is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string TaskName {  get; set; }
        public bool IsCompleted { get; set; }
    }
}
