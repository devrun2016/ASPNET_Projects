using System.ComponentModel.DataAnnotations;

namespace FoodFlow.Models
{
    public class Department
    {
        [Key]
        public int Dept_ID { get; set; }

        [Required]
        public string Dept_Name { get; set; }
    }
}
