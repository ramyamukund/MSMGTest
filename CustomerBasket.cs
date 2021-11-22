using MsPriceCalculator.Core;
using MsPriceCalculator.Core.Offers;
using MSPriceCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPriceCalculator
{
    
    public class ProductDiscount
    {
        public int ProductId { get; set; }
        public decimal Discount { get; set; }
        public ProductDiscount(int productId ,decimal  discount)
        {
            ProductId = productId;
            Discount = discount;
        }

    }
    public class CustomerBasket : ICustomerBasket
    {
        public int BasketId { get; set; }

        private readonly IEnumerable<IOffer> _offers;
        private readonly DiscountService _discountService = new DiscountService();
        private List<BasketItem> _basketItems = new List<BasketItem>();

        public CustomerBasket(IEnumerable<IOffer> offers)
        {
            _offers = offers ?? throw new ArgumentNullException(nameof(offers));
        }
       
        public void AddProducts(IEnumerable<BasketItem> items)
        {
            foreach(var item in items)
            {
                _basketItems.Add(item);
            }
        }

        public List<BasketItem> BasketItems
        {
            get
            {
                return _basketItems;
            }
        }
        public decimal SubTotal
        {
            get
            {
                return BasketItems
                    .Sum(x => x.Product.Price * x.Quantity);
            }
        }


        public List<ProductDiscount> GetDiscounts()
        {
            var productDiscounts = new List<ProductDiscount>();

           foreach(var item in _basketItems)
            {
                var discount = _discountService.ApplyDiscount(item, _basketItems, _offers);
                productDiscounts.Add(new ProductDiscount(item.Product.Id, discount));
            }

            return productDiscounts;
        }

        public decimal Total
        {
            get
            {
                var total = Math.Round(SubTotal - GetDiscounts().Sum(p => p.Discount), 2);
                return total;
            }
        }

    }
}
