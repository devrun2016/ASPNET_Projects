using System.ComponentModel.DataAnnotations;

namespace UrbanShop.Models
{
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string User_Account { get; set; }

        [Required]
        [MaxLength(255)]
        public string User_Password { get; set; }    
    }
}
