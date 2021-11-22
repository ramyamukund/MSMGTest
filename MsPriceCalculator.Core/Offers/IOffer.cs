using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPriceCalculator.Core.Offers
{
    public interface IOffer
    {
        bool isMatch(IEnumerable<BasketItem> basketItems, int currentProductId);

        decimal ApplyDiscount(IEnumerable<BasketItem> basketItems);

    }
}
