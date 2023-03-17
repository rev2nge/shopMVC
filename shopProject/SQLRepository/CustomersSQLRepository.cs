using shopProject.Models;
using shopProject.Interface;

namespace shopProject.SQLRepository
{
    public class CustomersSQLRepository : ICustomerRepository
    {
        private readonly ApplicationContext context;
        public CustomersSQLRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Customer Create(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer Update(Customer customer)
        {
            var customers = context.Customer.Attach(customer);
            customers.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customer;
        }

        public Customer Delete(int Id)
        {
            Customer customer = context.Customer.Find(Id);
            if (customer != null)
            {
                context.Customer.Remove(customer);
                context.SaveChanges();
            }
            return customer;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return context.Customer;
        }

        public Customer GetCustomerByID(int? Id)
        {
            return context.Customer.Find(Id);
        }
    }
}
