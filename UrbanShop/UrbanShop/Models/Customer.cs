using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanShop.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Customer_Name { get; set; }

        [Required,StringLength(50)]
        public string Customer_Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Customer_Phone { get; set; }

        // Foreign Key for Account
        public int Account_ID { get; set; }

        // Navigation property to Account
        [ForeignKey("Account_ID")]
        public Account Account { get; set; }
    }
}
