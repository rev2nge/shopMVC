using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopProject.Interface;
using shopProject.Models;
using shopProject.ViewModels.OViewModels;
using shopProject.ViewModels.PViewModels;

namespace shopProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productsRepository;

        public ProductsController(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ViewResult Index()
        {
            ProductsViewModel Products = new (_productsRepository.GetProduct());
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

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            if (Id != null)
            {
                Product products = _productsRepository.GetProductByID(Id);
                ProductsDeleteViewModel productsDeleteViewModel = new ProductsDeleteViewModel
                {
                    Id = products.Id,
                    ProductName = products.ProductName,
                    UnitPrice = products.UnitPrice,
                    Package = products.Package,
                    IsDiscontinued = products.IsDiscontinued
                };
                return View(productsDeleteViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            Product Products = _productsRepository.GetProductByID(Id);
            if (Products != null)
            {
                _productsRepository.Delete(Id);
                return RedirectToAction("Index");
            };
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductsCreateViewModel productsCreate)
        {
            if (productsCreate != null)
            {
                Product newProducts = new Product
                {
                    ProductName = productsCreate.ProductName,
                    UnitPrice = productsCreate.UnitPrice,
                    Package = productsCreate.Package,
                    IsDiscontinued = productsCreate.IsDiscontinued

                };
                _productsRepository.Create(newProducts);
                return RedirectToAction("Index", new { id = newProducts.Id });
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id != null)
            {
                Product products = _productsRepository.GetProductByID(Id);
                ProductsEditViewModel productsEdit = new ProductsEditViewModel
                {
                    Id = products.Id,
                    ProductName = products.ProductName,
                    UnitPrice = products.UnitPrice,
                    Package = products.Package,
                    IsDiscontinued = products.IsDiscontinued
                };
                return View(productsEdit);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProductsEditViewModel model)
        {
            Product products = _productsRepository.GetProductByID(model.Id);
            products.ProductName = model.ProductName;
            products.UnitPrice = model.UnitPrice;
            products.Package = model.Package;
            products.IsDiscontinued = model.IsDiscontinued;
            _productsRepository.Update(products);
            return RedirectToAction("Index");
        }
    }
}