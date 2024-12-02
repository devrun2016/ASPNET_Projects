using System.ComponentModel.DataAnnotations;

namespace FoodFlow.Models
{
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Account_Email { get; set; }

        [Required]
        [StringLength(255)]
        public required string Account_Password {  get; set; }

        public ICollection<User> Users { get; set; }
    }
}
