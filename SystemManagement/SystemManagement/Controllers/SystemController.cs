﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Orders")]
        public IActionResult GetOrders()
        {
            List<Order> orders = new List<Order>();
            OrderDao dao = new OrderDao();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            orders = dao.GetOrders(store);
            return Ok(orders);
        }

        [HttpPost("Orders")]
        public IActionResult SendOrder([FromBody]Order order)
        {
            OrderDao dao = new OrderDao();
            Console.WriteLine(order);
            dao.CreateOrder(order);
           
            return Index();
        }

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj};
            ProductDao dao = new ProductDao();

            List<Product> products = dao.GetProducts(store);
            return Ok(products);
        }
    }
}
