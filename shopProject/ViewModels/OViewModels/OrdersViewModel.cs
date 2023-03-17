using shopProject.Models;

namespace shopProject.ViewModels.OViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public OrdersViewModel(IEnumerable<Order> Order)
        {
            Orders = Order;
        }
    }
}
