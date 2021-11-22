using MsPriceCalculator.Core;
using MsPriceCalculator.Core.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPriceCalculator.Services
{
    public interface IDiscountService
    {
        decimal ApplyDiscount(BasketItem currentItem, List<BasketItem> basketIems, IEnumerable<IOffer> offers);
    }
}
