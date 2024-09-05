using System.ComponentModel.DataAnnotations;

namespace rui_ting_Project.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is requird.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
