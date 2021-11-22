using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsPriceCalculator.Core.Helpers;
using System.Collections.Generic;

namespace MSPriceCalculator.Tests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        [TestMethod]
        public void PriceCalculatorTest1()
        {
            var expected = 2.95M;

            var offers = Utils.CreateOffers();

            var basket = new CustomerBasket(offers);

            var basketItems = Utils.CreateProducts(new List<(string, string)> { ("butter", "1"), ("milk", "1"), ("bread", "1") });

            basket.AddProducts(basketItems);

            Assert.AreEqual(expected, basket.Total);
        }

        [TestMethod]
        public void PriceCalculatorTest2()
        {
            var expected = 3.10M;

            var offers = Utils.CreateOffers();

            var basket = new CustomerBasket(offers);

            var basketItems = Utils.CreateProducts(new List<(string, string)> { ("butter", "2"), ("bread", "2") });

            basket.AddProducts(basketItems);

            Assert.AreEqual(expected, basket.Total);
        }


        [TestMethod]
        public void PriceCalculatorTest3()
        {
            var expected = 9.00M;

            var offers = Utils.CreateOffers();

            var basket = new CustomerBasket(offers);

            var basketItems = Utils.CreateProducts(new List<(string, string)> { ("butter", "2"), ("milk", "8"), ("bread", "1") });

            basket.AddProducts(basketItems);

            Assert.AreEqual(expected, basket.Total);
        }

        [TestMethod]
        public void PriceCalculatorTest4()
        {
            var expected = 3.45M;

            var offers = Utils.CreateOffers();

            var basket = new CustomerBasket(offers);

            var basketItems = Utils.CreateProducts(new List<(string, string)> { ("milk", "4")});

            basket.AddProducts(basketItems);

            Assert.AreEqual(expected, basket.Total);
        }

    }
}
