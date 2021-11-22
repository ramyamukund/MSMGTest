using MsPriceCalculator.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSPriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                    

                    var offers = Utils.CreateOffers();

                    var basket = new CustomerBasket(offers);

                    var basketItems = Utils.CreateProducts(new List<(string, string)> { ("butter", "2") , ("milk", "8"), ( "bread", "1" ) }); 

                    basket.AddProducts(basketItems);
                    
                    Console.WriteLine("Total Price : " + $"{basket.Total}");
                    Console.ReadLine();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw new ApplicationException("An application error occurred", ex);
            }
        }
    }
}
