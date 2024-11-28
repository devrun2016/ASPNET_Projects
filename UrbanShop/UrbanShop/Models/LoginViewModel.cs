using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "User Account is required.")]
    public string User_Account { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
