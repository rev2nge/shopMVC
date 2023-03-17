using Microsoft.AspNetCore.Mvc;
using shopProject.Interface;
using shopProject.Models;
using shopProject.ViewModels.PViewModels;
using System.Diagnostics;

namespace shopProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationContext _applicationcontext;
        private readonly IProductRepository _productsRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IProductRepository productsRepository)
		{
			_logger = logger;
			_applicationcontext = context;
            _productsRepository = productsRepository;
        }
		public IActionResult Index()
		{
            ProductsViewModel Products = new(_productsRepository.GetProduct());
            return View(Products);
        }

        public ViewResult Details(int id)
        {
            ProductsDetailsViewModel productsDetailsViewModel = new ProductsDetailsViewModel()
            {
                Product = _productsRepository.GetProductByID(id)
            };

            return View(productsDetailsViewModel);
        }

        public IActionResult Privacy() 
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}