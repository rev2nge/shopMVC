using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopProject.Interface;
using shopProject.Models;
using shopProject.ViewModels;
using shopProject.ViewModels.OIViewModels;

namespace shopProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemRepository _orderItemsRepository;

        public OrderItemsController(IOrderItemRepository orderItemsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            OrderItemsViewModel OrderItems = new(_orderItemsRepository.GetOrderItem());
            return View(OrderItems);
        }

        public ViewResult Details(int id)
        {
            OrderItemsDetailsViewModel orderItemsDetailsViewModel = new OrderItemsDetailsViewModel()
            {
                OrderItem = _orderItemsRepository.GetOrderItemByID(id)
            };

            return View(orderItemsDetailsViewModel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            if (Id != null)
            {
                OrderItem orderItems = _orderItemsRepository.GetOrderItemByID(Id);
                OrderItemsDeleteViewModel orderItemsDeleteViewModel = new OrderItemsDeleteViewModel
                {
                    Id = orderItems.Id,
                    UnitPrice = orderItems.UnitPrice,
                    Quantity = orderItems.Quantity,
                    OrderId = orderItems.OrderId,
                    Order = orderItems.Order,
                    ProductId = orderItems.ProductId,
                    Product = orderItems.Product
                };
                return View(orderItemsDeleteViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            OrderItem OrderItems = _orderItemsRepository.GetOrderItemByID(Id);
            if (OrderItems != null)
            {
                _orderItemsRepository.Delete(Id);
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
        public IActionResult Create(OrderItemsCreateViewModel orderItems)
        {
            if (orderItems != null)
            {
                OrderItem newOrderItems = new OrderItem
                {
                    UnitPrice = orderItems.UnitPrice,
                    Quantity = orderItems.Quantity,
                    OrderId = orderItems.OrderId,
                    Order = orderItems.Order,
                    ProductId = orderItems.ProductId,
                    Product = orderItems.Product
                };
                _orderItemsRepository.Create(newOrderItems);
                return RedirectToAction("Index", new { id = newOrderItems.Id });
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id != null)
            {
                OrderItem orderItems = _orderItemsRepository.GetOrderItemByID(Id);
                OrderItemsEditViewModel orderItemEditViewModel = new OrderItemsEditViewModel
                {
                    Id = orderItems.Id,
                    UnitPrice = orderItems.UnitPrice,
                    Quantity = orderItems.Quantity,
                    OrderId = orderItems.OrderId,
                    Order = orderItems.Order,
                    ProductId = orderItems.ProductId,
                    Product = orderItems.Product
                };
                return View(orderItemEditViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(OrderItemsEditViewModel model)
        {
            OrderItem orderItems = _orderItemsRepository.GetOrderItemByID(model.Id);
            orderItems.UnitPrice = model.UnitPrice;
            orderItems.Quantity = model.Quantity;
            orderItems.OrderId = model.OrderId;
            orderItems.Order = model.Order;
            orderItems.ProductId = model.ProductId;
            orderItems.Product = model.Product;
            _orderItemsRepository.Update(orderItems);
            return RedirectToAction("Index");
        }
    }
}