using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock; 
        }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";
        public Product Related { get; set; }
        public bool InStock { get; }
        public bool NameBeginsWithS => Name?[0] == 's'; 
        public static Product[] GetProducts()
        {
            Product Kayake = new Product()
            {
                Name = "Kayake",
                Category = "Water Craft",
                Price = 275m
            };

            Product LifeJacket = new Product(false)
            {
                Name = "Life Jacket",
                Price = 48.95m
            };
            Kayake.Related = LifeJacket; 

            return new Product[] { Kayake, LifeJacket, null }; 
        }
    }
}
