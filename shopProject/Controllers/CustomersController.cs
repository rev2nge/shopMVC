using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopProject.Models;
using shopProject.Interface;
using shopProject.ViewModels;
using shopProject.ViewModels.CViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using shopProject.ViewModels.OIViewModels;

namespace shopProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomersController(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            CustomersViewModel Customers = new(_customersRepository.GetCustomer());
            return View(Customers);
        }

        public ViewResult Details(int id)
        {
            CustomersDetailsViewModel customersDetailsViewModel = new CustomersDetailsViewModel()
            {
                Customer = _customersRepository.GetCustomerByID(id)
            };

            return View(customersDetailsViewModel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            if (Id != null)
            {
                Customer customers = _customersRepository.GetCustomerByID(Id);
                CustomersDeleteViewModel customersDeleteViewModel = new CustomersDeleteViewModel
                {
                    Id = customers.Id,
                    FirstName = customers.FirstName,
                    LastName = customers.LastName,
                    City = customers.City,
                    Country = customers.Country,
                    Phone = customers.Phone
                };
                return View(customersDeleteViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            Customer customers = _customersRepository.GetCustomerByID(Id);
            if (customers != null)
            {
                _customersRepository.Delete(Id);
                return RedirectToAction("Index");
            };
            return NotFound();
        }

        [HttpGet]
        [ActionName("Create")]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CustomersCreateViewModel customersCreate)
        {
            if (customersCreate != null)
            {
                Customer newCustomers = new Customer
                {
                    FirstName = customersCreate.FirstName,
                    LastName = customersCreate.LastName,
                    City = customersCreate.City,
                    Country = customersCreate.Country,
                    Phone = customersCreate.Phone
                };
                _customersRepository.Create(newCustomers);
                return RedirectToAction("Index", new { id = newCustomers.Id });
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id != null)
            {
                Customer customers = _customersRepository.GetCustomerByID(Id);
                CustomersEditViewModel customerEditViewModel = new CustomersEditViewModel
                {
                    Id = customers.Id,
                    FirstName = customers.FirstName,
                    LastName = customers.LastName,
                    City = customers.City,
                    Country = customers.Country,
                    Phone = customers.Phone
                };
                return View(customerEditViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(CustomersEditViewModel model)
        {
            Customer customers = _customersRepository.GetCustomerByID(model.Id);
            customers.FirstName = model.FirstName;
            customers.LastName = model.LastName;
            customers.City = model.City;
            customers.Country = model.Country;
            customers.Phone = model.Phone;
            _customersRepository.Update(customers);
            return RedirectToAction("Index");
        }
    }
}