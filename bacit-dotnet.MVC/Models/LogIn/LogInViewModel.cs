using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.LogIn;

public class LogInViewModel
{
    [Required]
    [EmailAddress]
    public  string Email { get; set; }
    
    [Required]
    [EmailAddress]
    public  string Password { get; set; }
}