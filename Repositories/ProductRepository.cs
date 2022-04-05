
using Newtonsoft.Json;
using API.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace API.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductsByName(string productName);
        void AddProductVoid(string productName, string productDescription,int[] productReviews);
        void DeleteProduct(Guid id);
    }
    public class ProductRepository : IProductRepository
    {

        private  static IEnumerable<Product> _products = DataCreator.ReadFromJsonFile();
        private static List<Product> _produsele = DataCreator.ReadFromJsonFile().ToList();
        public IEnumerable<Product> GetProducts()
        {
            return _produsele;
        }
        public Product GetProductsByName(string productName)
        {
            foreach (Product product in _products)
            {
                if (product.Name.ToLower() == productName.ToLower())
                    return product;
            }
            return null;
        }

      

        //try add void 
        public void AddProductVoid(string productName,string productDescription, int[] productReviews)
        {
            Product newProduct = new Product(productName, productDescription, productReviews);
            _produsele.Add(newProduct);
            string path = @"C:\Users\andrei.musca\Desktop\Proiecte\API\Data\data.txt";
            var products = JsonConvert.SerializeObject(_produsele);
            File.WriteAllText(path, products);
        }

        //delete after id
        public void DeleteProduct(Guid id)
        {
            var del=_produsele.FirstOrDefault(a => a.Id == id);
            _produsele.Remove(del);
            string path = @"C:\Users\andrei.musca\Desktop\Proiecte\API\Data\data.txt";
            var products = JsonConvert.SerializeObject(_produsele);
            File.WriteAllText(path, products);
        }
    }


    public class DataCreator
    {
        static string CreateJsonDataFile()
        {
            string path = @"C:\Users\andrei.musca\Desktop\Proiecte\API\Data\data.txt";
            FileStream fs = File.OpenRead(path);
            if (fs.Length == 0)
            {

                List<Product> productList = new List<Product>()
            {
                new Product("Laptop HP Probook","A regular office laptop.",new[]{5,4,4,5,3,4,5,2}),
                new Product("Jabra Evolve","The perfect headest for gaming.",new[]{2,5,3,4,1,3,2}),
                new Product("Nvidia RTX 3090 Ti","#1 graphic card around the world.",new[]{5,5,5,5,5,5,5,5,5}),
                new Product("Slippery cup","A cup for your every day use :)",new[]{1,1,2,1,2,1,1,2,2,2,1}),
                new Product("Card Holder","For the ones that thinkg that the era of cash is over!",new[]{5,4,4,3,5,4,5,5,5,4,4,5,4,3}),
            };

                var productsJson = JsonConvert.SerializeObject(productList);
                File.WriteAllText(path, productsJson);

                fs.Close();
                return path;
            }
            else
            {
                fs.Close();
                return path;
            }
        }

        public static IEnumerable<Product> ReadFromJsonFile()
        {
            string unserielisedJsonFile = File.ReadAllText(CreateJsonDataFile());

            return JsonConvert.DeserializeObject<IEnumerable<Product>>(unserielisedJsonFile);
        }
    }
}
