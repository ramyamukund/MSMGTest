using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPriceCalculator.Core.Offers
{
    class FourForThreeOffer : IOffer
    {
        private readonly int _orderLimit;
        private readonly int _discountedProductId;

        public FourForThreeOffer(int orderLimit, int productId)
        {
            _orderLimit = orderLimit;
            _discountedProductId = productId;

        }

        public decimal ApplyDiscount(IEnumerable<BasketItem> basketItems)
        {
            foreach (var item in basketItems)
            {
                if (item.Quantity % _orderLimit == 0 && item.Product.Id == _discountedProductId)
                {
                    var discountApplicableTimes = item.Quantity / _orderLimit;
                    return Math.Round(item.Product.Price * discountApplicableTimes, 2);

                }
            }

            return 0.0M;
        }

        public bool isMatch(IEnumerable<BasketItem> basketItems, int currProductId)
        {
            foreach (var item in basketItems)
            {
                if (item.Quantity % _orderLimit == 0 && currProductId == _discountedProductId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
