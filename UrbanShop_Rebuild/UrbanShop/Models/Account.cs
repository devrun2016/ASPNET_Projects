using System.ComponentModel.DataAnnotations;

namespace UrbanShop.Models
{
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
