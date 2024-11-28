using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UrbanShop.Models
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Customer_Name { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(50)]
        public string Customer_Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string Customer_Phone { get; set; }

        [Required]
        [Display(Name = "User Account")]
        [StringLength(10, ErrorMessage = "User Account cannot exceed 10 characters.")]
        public string User_Account { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("User_Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
