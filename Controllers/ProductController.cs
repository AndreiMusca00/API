using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Managers;
using API.Models;
using System.Collections.Generic;
using System;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productManager.GetProducts();
        }

        [HttpGet]
        [Route("GetByName")]
        public Product GetProductByName(string productName)
        {
            return _productManager.GetProductByName(productName);
        }
        
        [HttpPost]
        [Route("AddVoid")]
        public void AddProductVoid(string productName,string productDescription,int[] productReviews)
        {
            _productManager.AddProductVoid(productName, productDescription, productReviews);
        }

        [HttpDelete]
        public void DeleteProduct(Guid id)
        {
            _productManager.DeleteProduct(id);
        }

        [HttpGet]
        [Route("FilterByName")]
        public IEnumerable<Product> GetFiltered(string Filter)
        {
            return _productManager.GetFiltered(Filter);
        } 
    }
}
