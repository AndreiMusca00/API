using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Managers;
using System.Collections.Generic;
using API.Models;
using System;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager _productsManager;
         public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _productsManager.GetProducts();
        }

        [HttpGet]
        [Route("GetByName")]
        public Products GetProductByName(string productName)
        {
            
            return _productsManager.GetProductByName(productName);
        }
        [HttpPost]
        public Products AddProduct(Products product)
        {
            return _productsManager.AddProduct(product);
        }

        [HttpDelete]
        public Products DeleteProduct(string name)
        {
           return _productsManager.DeleteProduct(name);
        }

    }
}
