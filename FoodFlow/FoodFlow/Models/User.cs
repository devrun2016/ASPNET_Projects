using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFlow.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public required string User_FullName { get; set; }

        [StringLength(20)]
        public string User_Phone { get; set; }

        [ForeignKey("Account")]
        public int Account_ID { get; set; }

        public Account Account { get; set; }
    }
}
