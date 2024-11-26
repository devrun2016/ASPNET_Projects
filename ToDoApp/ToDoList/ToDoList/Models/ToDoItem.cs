using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TaksName {  get; set; }

        public bool isCompleted {  get; set; }
    }
}
