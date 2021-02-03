using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.DataAccess
{
    
    
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders(int customerId);
    }

    public class OrderRepository : IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders(int customerId)
        {

            //IEnumerable<Order> orders = GetRandomOrders();

            //return orders;

            throw new NotImplementedException();
        }



        private IEnumerable<Order> GetRandomOrders(int numberOfOrders = 3)
        {

            List<Order> returnOrders = new List<Order>();
            
            for (int i = 1; i <= numberOfOrders; i++)
            {
                returnOrders.Add(Order.GenerateRandomOrder());
            }

            return returnOrders;
        }


    }
}
