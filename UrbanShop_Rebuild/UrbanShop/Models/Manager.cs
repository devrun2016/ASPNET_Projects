using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanShop.Models
{
    public class Manager
    {
        [Key]
        public int Manager_ID { get; set; }

        [Required]
        public string email { get; set; }

        public int Account_ID { get; set; }

        [ForeignKey("Account_ID")]
        public Account Account { get; set; }
    }
}
