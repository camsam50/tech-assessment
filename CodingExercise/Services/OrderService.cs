using CodingExercise.DataAccess;
using CodingExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingExercise.Services
{
    
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetCustomerOrders(int customerId);
        public Task CreateOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task<Order> GetOrder(int orderId);
        public Task CancelOrder(int orderId);
    }
    
    public class OrderService : IOrderService
    {

        //	List all orders by customer endpoint
        //  Create new order
        //	Update order endpoint
        //	Cancel order endpoint


        private readonly OrderContext _context;

        public OrderService(OrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(int customerId)
        {
            return await _context.Orders.Where(f => f.CustomerId == customerId).ToListAsync();
        }

        public async Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

        }
        public async Task<Order> GetOrder(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task CancelOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order with that id was not found to cancel.", nameof(orderId));
                
            }   

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

        }

        
    }
}
