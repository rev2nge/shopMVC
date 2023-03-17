using Microsoft.AspNetCore.Mvc;
using shopProject.Utilities;
using System.ComponentModel.DataAnnotations;

namespace shopProject.ViewModels.AccountViewModels
{
    public class RegisterViewModels
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomain(allowedDomain: "gmail.com", 
            ErrorMessage = " Email domain must be @gmail.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation passworf do not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
