using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid formt email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwork is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords dont´t match")]
        public string ConfirmPassword { get; set; }
    }
}
