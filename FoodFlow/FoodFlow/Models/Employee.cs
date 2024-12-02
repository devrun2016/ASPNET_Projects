using System.ComponentModel.DataAnnotations;

namespace FoodFlow.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Name { get; set; } = string.Empty;

        [Required]
        public DateTime Employee_DoB { get; set; }

        [Required]
        [StringLength(10)]
        public string Employee_Gender { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Employee_Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Employee_Phone { get; set; } = string.Empty;
    }
}
