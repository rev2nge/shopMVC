using shopProject.Models;

namespace shopProject.ViewModels.OIViewModels
{
    public class OrderItemsViewModel
    {
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public OrderItemsViewModel(IEnumerable<OrderItem> OrderItem)
        {
            OrderItems = OrderItem;
        }
    }
}
