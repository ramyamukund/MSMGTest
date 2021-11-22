using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPriceCalculator.Core.Offers
{
    public class Buy2GetXPercentageOnYOffer : IOffer
    {
        private readonly int _orderLimit;
        private readonly int _discountOnProductId;
        private readonly int _discountedProductId;
        private decimal _discountPercentage;

     
        public Buy2GetXPercentageOnYOffer(int orderLimit, int discountOnProductId, int discountedProductId, decimal discountPercentage)
        {
            _orderLimit = orderLimit;
            _discountOnProductId = discountOnProductId;
            _discountedProductId = discountedProductId;
            _discountPercentage = discountPercentage;

        }

        public decimal ApplyDiscount(IEnumerable<BasketItem> basketItems)
        {
            if (basketItems.Any(x => x.Product.Id == _discountedProductId))
            {
                return Math.Round(basketItems.Where(i => i.Product.Id == _discountedProductId).FirstOrDefault().Product.Price * _discountPercentage, 2);
             }

            return 0.0M;
        }
        public bool isMatch(IEnumerable<BasketItem> basketItems, int currProductId)
        {
            
                foreach (var item in basketItems)
                {
                    if (item.Quantity == _orderLimit && currProductId == _discountOnProductId)
                    {
                        if (basketItems.Any(x => x.Product.Id == _discountedProductId))
                        {
                            return true;
                        }
                    }
                }
            
            return false;
        }

    }
}
