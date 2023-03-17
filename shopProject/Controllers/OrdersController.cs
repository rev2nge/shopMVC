using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopProject.Interface;
using shopProject.Models;
using shopProject.ViewModels.OViewModels;

namespace shopProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _ordersRepository;

        public OrdersController(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            OrdersViewModel Orders = new(_ordersRepository.GetOrder());
            return View(Orders);
        }

        public ViewResult Details(int id)
        {
            OrdersDetailsViewModel ordersDetailsViewModel = new OrdersDetailsViewModel()
            {
                Order = _ordersRepository.GetOrderByID(id)
            };

            return View(ordersDetailsViewModel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            if (Id != null)
            {
                Order orders = _ordersRepository.GetOrderByID(Id);
                OrdersDeleteViewModel ordersDeleteViewModel = new OrdersDeleteViewModel
                {
                    Id = orders.Id,
                    OrderDate = orders.OrderDate,
                    TotalAmount = orders.TotalAmount,
                    CustomerId = orders.CustomerId,
                    Customer = orders.Customer
                };
                return View(ordersDeleteViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            Order Orders = _ordersRepository.GetOrderByID(Id);
            if (Orders != null)
            {
                _ordersRepository.Delete(Id);
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
        public IActionResult Create(OrdersCreateViewModel ordersCreate)
        {
            if (ordersCreate != null)
            {
                Order newOrders = new Order
                {
                    OrderDate = ordersCreate.OrderDate,
                    TotalAmount = ordersCreate.TotalAmount,
                    CustomerId = ordersCreate.CustomerId,
                    Customer = ordersCreate.Customer
                    
                };
                _ordersRepository.Create(newOrders);
                return RedirectToAction("Index", new { id = newOrders.Id });
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id != null)
            {
                Order orders = _ordersRepository.GetOrderByID(Id);
                OrdersEditViewModel ordersEditViewModel = new OrdersEditViewModel
                {
                    Id = orders.Id,
                    OrderDate = orders.OrderDate,
                    TotalAmount = orders.TotalAmount,
                    CustomerId = orders.CustomerId,
                    Customer = orders.Customer
                };
                return View(ordersEditViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(OrdersEditViewModel model)
        {
            Order orders = _ordersRepository.GetOrderByID(model.Id);
            orders.OrderDate = model.OrderDate;
            orders.TotalAmount = model.TotalAmount;
            orders.CustomerId = model.CustomerId;
            orders.Customer = model.Customer;
            orders.OrderNumber = model.OrderNumber;
            _ordersRepository.Update(orders);
            return RedirectToAction("Index");
        }
    }
}