using shopProject.Models;
using System.Drawing.Drawing2D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shopProject
{
    public static class Seed
    {
       
        public static List<Customer> GetCustomer()
        {
            List<Customer> list = new List<Customer>()
            {
                new Customer() {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Anders",
                    City = "Berlin",
                    Country = "Germany",
                    Phone = "030-0074322"
                }
                
            };
            return list;
        }

        public static List<Order> GetOrder()
        {
            List<Order> list = new List<Order>()
            {
                new Order() {
                    Id = 1,
                    OrderDate = new DateTime(2012, 07, 04),
                    OrderNumber = "542378",
                    CustomerId = 1,
                    TotalAmount = (decimal) 400.00,
                }

            };
            return list;
        }
    }
}
