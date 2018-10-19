using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository: IRepository
    {
        private static SimpleRepository sharedRepository => new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;

        public SimpleRepository()
        {
            var InitialItems = new[]
            {
                new Product {Name = "Kayak", Price = 275m },
                new Product {Name = "Lifejacket", Price = 48.95m },
                new Product {Name = "Soccer Ball", Price = 19.50m },
                new Product {Name = "Corner Flag", Price = 34.95m }
            };

            // Adding all of the intial items to the repository. 
            foreach (var product in InitialItems)
            {
                AddProduct(product);
            }
        }

        public IEnumerable<Product> Products => products.Values;

        // Setting the dictionary up with the intial values and setting the key to the name of the product and the value to the product itself.
        public void AddProduct(Product product) => products.Add(product.Name, product);
        
    }
}
