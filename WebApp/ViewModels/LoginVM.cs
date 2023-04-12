using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginVM
    {
        // Email
        [EmailAddress]
        public string Email { get; set; }
        // Paswword
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
