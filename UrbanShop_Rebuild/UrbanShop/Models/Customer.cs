using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanShop.Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_Name { get; set; }

        [Required, StringLength(100)]
        public string Customer_Phone { get; set; }

        // Foreign Key
        public int Account_ID { get; set; }

        [ForeignKey("Account_ID")]
        public Account Account { get; set; }
    }
}
