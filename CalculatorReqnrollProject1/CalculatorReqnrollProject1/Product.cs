using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorReqnrollProject1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product {Name="laptop", Price=50000.00},
                new Product {Name="Nutella", Price=1000.00},
                new Product {Name="Mobile", Price=5000.00},
            };
            return products;
        }
    }
}
