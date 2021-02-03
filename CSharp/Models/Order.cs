using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int Price { get; set; }
        public Customer Customer { get; set; }


        public static Order GenerateRandomOrder()
        {
            Random randomNumberGenerator = new Random();
            
            return new Order()
            {
                OrderId = new Guid(),
                Price = randomNumberGenerator.Next(1,100)

            };
        }
    }
}
