using System.ComponentModel.DataAnnotations;

namespace UrbanShop.Models
{
    public class AccountCustomerViewModel
    {
        [Required]
        public string ac_email { get; set; }

        [Required]
        public string ac_password { get; set; }

        [Required]
        public string ac_name { get; set; }

        [Required]
        public string ac_phone { get; set; }

    }
}
