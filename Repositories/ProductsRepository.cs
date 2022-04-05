using API.Models;
using System.Collections.Generic;
using System;
using Newtonsoft;
namespace API.Repositories
{
    public interface IProductsRepository
    {
        List<Products> GetProducts();
        
        Products AddProduct(Products products);
        Products DeleteProduct(string name);
    }
    public class ProductsRepository :IProductsRepository
    {  
      
        static List<Products> list = new List<Products>
        {
            new Products("Mouse","Mouse de gaming", new []{3,4,2,4}),
            new Products("Tastatura","Tastatura office", new []{3,5,1,2}),
            new Products("Monitor","Monior 144hz", new []{1,2,2,3})
        };
        
        public List<Products> GetProducts()
        {
            return list;
        }

        public Products DeleteProduct(string name)
        {
            foreach (Products products in list)
            {
                if(products.Name == name)
                    list.Remove(products);
                return products;
            }
            return null;
        }
        public Products AddProduct(Products product)
        {
            list.Add(product);
            return product;
        }
    }
}
