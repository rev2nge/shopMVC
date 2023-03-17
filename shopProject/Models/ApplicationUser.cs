using Microsoft.AspNetCore.Identity;

namespace shopProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
