using API.Repositories;
using System.Collections.Generic;
using API.Models;
using System;
namespace API.Managers
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByName(string productName);
        void AddProductVoid(string productName, string productDescription, int[] productRatings);
        void DeleteProduct(Guid id);
        IEnumerable<Product> GetFiltered(string Filter);
    }

    public class ProductManager:IProductManager
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProductByName(string productName)
        {
            return _productRepository.GetProductsByName(productName);
        }


      
        //try add void 
        public void AddProductVoid(string productName,string productDescription, int[] productRatings)
        {
            _productRepository.AddProductVoid(productName,productDescription,productRatings);
        }

        //delete afeter guid 
        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        //filtrare dupa nume sau descriere
        public IEnumerable<Product> GetFiltered(string Filter)
        {
            var produse = _productRepository.GetProducts();
            List<Product> products = new List<Product>();
            foreach(var product in produse)
            {
                if (product.Name.ToString().Contains(Filter)||product.Description.ToString().Contains(Filter))
                {
                    products.Add(product);
                }
            }
            return products;
        }
        //ordonare dupa avg rating 
        public int AverageRating(int[] arr)
        {
            int sum = 0;
            int k = 0;
            for(int i=0;i<arr.Length;i++)
            {
                sum+=arr[i];
                k++;
            }
            return sum / k;
        }
        public IEnumerable<Product> OrderByRating()
        {
            var produse = _productRepository.GetProducts();
            List<Product> pr = (List<Product>)produse;
            //pr.
            foreach (var item in produse)
            {
               int avg = AverageRating(item.Ratings);
                
            }
            return null;
        }

    }
}
