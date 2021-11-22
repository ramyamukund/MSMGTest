using MsPriceCalculator.Core.Factories;
using MsPriceCalculator.Core.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPriceCalculator.Core.Helpers
{
    public class Utils 
    {

        public static IEnumerable<IOffer> CreateOffers()
        {

            return new List<IOffer>
            {
                new FourForThreeOffer( 4 , 2),

                new Buy2GetXPercentageOnYOffer(2 , 1, 3, 0.5m)
            };
        }
        public static IEnumerable<BasketItem> CreateProducts(List<(string, string)> products)
        {
            var basketItems = new List<BasketItem>();

            var productFactory = new ProductFactory();

            foreach (var product in products)
            {
                    basketItems.Add(new BasketItem
                    {
                        Product = productFactory.CreateProduct(product.Item1),
                        Quantity = int.Parse(product.Item2)
                    });
                
            }

            return basketItems;
        }

    }
    
}
