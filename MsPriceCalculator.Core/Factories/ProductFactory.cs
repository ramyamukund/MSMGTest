using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPriceCalculator.Core.Factories
{
    public class ProductFactory
    {

        public Product CreateProduct(string productName)
        {
            switch (productName.ToLower())
            {
                case "butter":
                    return new Product
                    {
                        Id = 1,
                        Name = "Butter",
                        Price = 0.80m
                    };
                case "milk":
                    return new Product
                    {
                        Id = 2,
                        Name = "Milk",
                        Price = 1.15m
                    };
                case "bread":
                    return new Product
                    {
                        Id = 3,
                        Name = "Bread",
                        Price = 1.00m
                    };
               
                default:
                    throw new NotSupportedException($" product doesnt exists : {productName.ToLower()}");
            }
        }
    }
}
