using API.Repositories;
using API.Models;
using System.Linq;
using System.Collections.Generic;
using System;
namespace API.Managers
{
    public interface IProductsManager
    {
        IEnumerable<Products> GetProducts();
        Products GetProductByName(string productName);
        Products AddProduct(Products product);

        Products DeleteProduct(string name);
    }
    public class ProductsManager:IProductsManager
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsManager(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public IEnumerable<Products> GetProducts()
        {
            var products = _productsRepository.GetProducts();
           
            return products;
        }
        public Products GetProductByName(string productName)
        {
            var list = _productsRepository.GetProducts();
            foreach (var product in list)
            {
                if (product.Name == productName)
                    return product;
            }
            return null;
        }

        public Products DeleteProduct(string name)
        {
            return _productsRepository.DeleteProduct(name);
        }
        public Products AddProduct(Products product)
        {
           return _productsRepository.AddProduct(product);
        }
    }
}
