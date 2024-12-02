using System.ComponentModel.DataAnnotations;

namespace FoodFlow.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Email is requried for sign in.")]
        [EmailAddress(ErrorMessage = "Invalid email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required for sign in.")]
        public string Password { get; set; }
    }
}
