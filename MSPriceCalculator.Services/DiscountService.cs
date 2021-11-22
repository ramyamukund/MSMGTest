using MsPriceCalculator.Core;
using MsPriceCalculator.Core.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPriceCalculator.Services
{
    public class DiscountService : IDiscountService
    {
        public DiscountService()
        {

        }
        public decimal ApplyDiscount(BasketItem currentItem, List<BasketItem> basketIems, IEnumerable<IOffer> offers)
        {
           foreach(var offer in offers)
            {
                if(offer.isMatch(basketIems, currentItem.Product.Id))
                {
                    return offer.ApplyDiscount(basketIems);
                }

            }

            return 0.0M;
        }

       
    }
}
