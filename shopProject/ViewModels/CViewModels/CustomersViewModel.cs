using shopProject.Models;

namespace shopProject.ViewModels.CViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public CustomersViewModel(IEnumerable<Customer> Customer)
        {
            Customers = Customer;
        }
    }
}
