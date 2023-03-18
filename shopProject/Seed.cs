using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shopProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shopProject
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Customer custOne = new Customer()
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Anders",
                City = "Berlin",
                Country = "Germany",
                Phone = "030-0074322"
            };
            Customer custTwo = new Customer()
            {
                Id = 2,
                FirstName = "Ana",
                LastName = "Trujillo",
                City = "Mexico D.F.",
                Country = "Mexico",
                Phone = "(5) 555-4729"
            };
            Customer custThree = new Customer()
            {
                Id = 3,
                FirstName = "Antonio",
                LastName = "Moreno",
                City = "Mexico D.F.",
                Country = "Mexico",
                Phone = "(5) 555-3932"
            };
            Customer custFour = new Customer()
            {
                Id = 4,
                FirstName = "Thomas",
                LastName = "Hardy",
                City = "London",
                Country = "UK",
                Phone = "(171) 555-7788"
            };
            Customer custFive = new Customer()
            {
                Id = 5,
                FirstName = "Christina",
                LastName = "Berglund",
                City = "Lulea",
                Country = "Sweden",
                Phone = "0921-12 34 65"
            };

            OrderItem orditOne = new OrderItem()
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                UnitPrice = (decimal)14.00,
                Quantity = 12
            };
            OrderItem orditTwo = new OrderItem()
            {
                Id = 2,
                OrderId = 2,
                ProductId = 2,
                UnitPrice = (decimal)9.80,
                Quantity = 10
            };
            OrderItem orditThree = new OrderItem()
            {
                Id = 3,
                OrderId = 3,
                ProductId = 3,
                UnitPrice = (decimal)34.80,
                Quantity = 5
            };
            OrderItem orditFour = new OrderItem()
            {
                Id = 4,
                OrderId = 4,
                ProductId = 4,
                UnitPrice = (decimal)18.60,
                Quantity = 9
            };
            OrderItem orditFive = new OrderItem()
            {
                Id = 5,
                OrderId = 5,
                ProductId = 5,
                UnitPrice = (decimal)42.40,
                Quantity = 40
            };

            Order ordOne = new Order()
            {
                Id = 1,
                OrderDate = new DateTime(2012-07-04),
                OrderNumber = "542378",
                CustomerId = 1,
                TotalAmount = (decimal)440.00
            };
            Order ordTwo = new Order()
            {
                Id = 2,
                OrderDate = new DateTime(2012-07-05),
                OrderNumber = "542379",
                CustomerId = 2,
                TotalAmount = (decimal)1863.40
            };
            Order ordThree = new Order()
            {
                Id = 3,
                OrderDate = new DateTime(2012-07-08),
                OrderNumber = "542380",
                CustomerId = 3,
                TotalAmount = (decimal)1813.00
            };
            Order ordFour = new Order()
            {
                Id = 4,
                OrderDate = new DateTime(2012-07-08),
                OrderNumber = "542381",
                CustomerId = 4,
                TotalAmount = (decimal)670.80
            };
            Order ordFive = new Order()
            {
                Id = 5,
                OrderDate = new DateTime(2012-07-09),
                OrderNumber = "542382",
                CustomerId = 5,
                TotalAmount = (decimal)3730.00
            };

            Product prodOne = new Product()
            {
                Id = 1,
                ProductName = "Chai",
                UnitPrice = (decimal)18.00,
                Package = "10 boxes x 20 bags",
                IsDiscontinued = false
            };
            Product prodTwo = new Product()
            {
                Id = 2,
                ProductName = "Chang",
                UnitPrice = (decimal)19.00,
                Package = "24 - 12 oz bottles",
                IsDiscontinued = false
            };
            Product prodThree = new Product()
            {
                Id = 3,
                ProductName = "Aniseed Syrup",
                UnitPrice = (decimal)10.00,
                Package = "12 - 550 ml bottles",
                IsDiscontinued = false
            };
            Product prodFour = new Product()
            {
                Id = 4,
                ProductName = "Chef Anton's Cajun Seasoning",
                UnitPrice = (decimal)22.00,
                Package = "48 - 6 oz jars",
                IsDiscontinued = false
            };
            Product prodFive = new Product()
            {
                Id = 5,
                ProductName = "Chef Anton's Gumbo Mix",
                UnitPrice = (decimal)21.35,
                Package = "36 boxes",
                IsDiscontinued = true
            };

            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                  Name = "admin",
                  NormalizedName = "ADMIN",
              },
              new IdentityRole
              {
                  Id = "21231e07-3212-3bc8-b88a-f336ae9d6eab",
                  Name = "employee",
                  NormalizedName = "EMPLOYEE",
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

                },
                new ApplicationUser
                {
                    Id = "5b56472e-3v66-49fa-a20f-e6545b3283d8",
                    UserName = "employee@gmail.com",
                    NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                    Email = "employee@gmail.com",
                    NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "654321"),
                    SecurityStamp = string.Empty,
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "21231e07-3212-3bc8-b88a-f336ae9d6eab",
                UserId = "5b56472e-3v66-49fa-a20f-e6545b3283d8",
            });

            modelBuilder.Entity<Customer>().HasData(custOne, custTwo, custThree, custFour, custFive);
            modelBuilder.Entity<OrderItem>().HasData(orditOne, orditTwo, orditThree, orditFour, orditFive);
            modelBuilder.Entity<Order>().HasData(ordOne, ordTwo, ordThree, ordFour, ordFive);
            modelBuilder.Entity<Product>().HasData(prodOne, prodTwo, prodThree, prodFour, prodFive);
        }
    }
}
