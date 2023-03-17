using shopProject.Models;
using System.ComponentModel.DataAnnotations;

namespace shopProject.ViewModels.OViewModels
{
    public class OrdersDeleteViewModel
    {
        public int? Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
