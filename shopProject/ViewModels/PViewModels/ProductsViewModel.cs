using shopProject.Models;

namespace shopProject.ViewModels.PViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductsViewModel(IEnumerable<Product> Product)
        {
            Products = Product;
        }
    }
}
