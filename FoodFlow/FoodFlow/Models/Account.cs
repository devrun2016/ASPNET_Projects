using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFlow.Models
{
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Account_Email { get; set; }

        [StringLength(255)]
        public required string Account_Password {  get; set; }

        public ICollection<User> Users { get; set; }
    }
}
