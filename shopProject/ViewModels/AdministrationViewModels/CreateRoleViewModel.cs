using System.ComponentModel.DataAnnotations;

namespace shopProject.ViewModels.AdministrationViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string? RoleName { get; set; }
    }
}
