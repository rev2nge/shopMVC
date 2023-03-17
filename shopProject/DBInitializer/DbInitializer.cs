/*using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shopProject.Models;

namespace shopProject.DBInitializer

{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             ApplicationContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (! _roleManager.RoleExistsAsync(SD.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.EmployeeRole)).GetAwaiter().GetResult();
            }
        }
    }
}
*/