using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace shopProject.Models
{
    public class ApplicationContext : IdentityDbContext<IdentityUser> // Context
    {
        // Добавляет  
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderItem> OrderItem { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
               : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                   Name = "admin",
                   NormalizedName = "ADMIN",

               });
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "123456"),
                    SecurityStamp = string.Empty,
             
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8",

            });

            modelBuilder.Entity<Customer>().HasData(Seed.GetCustomer());
            modelBuilder.Entity<Order>().HasData(Seed.GetOrder());
        }
    }
}
