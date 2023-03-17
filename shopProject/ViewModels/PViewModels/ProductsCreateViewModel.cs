using shopProject.Models;

namespace shopProject.ViewModels.PViewModels
{
    public class ProductsCreateViewModel
    {
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Package { get; set; }
        public bool? IsDiscontinued { get; set; }
    }
}
