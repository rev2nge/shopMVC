using shopProject.Models;

namespace shopProject.ViewModels.OIViewModels
{
    public class OrderItemsCreateViewModel
    {
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
