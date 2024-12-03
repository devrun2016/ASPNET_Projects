using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFlow.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }

        [Required]
        public string Emp_Name { get; set; }

        [Required]
        public string Emp_Phone { get; set; }

        [Required]
        public string Emp_Email { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }

        public Department Department { get; set; }
    }
}
