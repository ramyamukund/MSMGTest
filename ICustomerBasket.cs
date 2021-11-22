using MsPriceCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPriceCalculator
{
    interface ICustomerBasket
    {
        void AddProducts(IEnumerable<BasketItem> items);
    }
}
