using System.ComponentModel.DataAnnotations;

namespace AuthorizationNETCore.DatabasePractice.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }
    }
}
