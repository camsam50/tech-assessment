using CodingExercise.DataAccess;
using CodingExercise.Models;
using CodingExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        //What we would like to see from this exercise:
        //	Create order endpoint
        //	List all orders by customer endpoint
        //	Update order endpoint
        //	Cancel order endpoint
        //	Tests to prove your code works as expected


        private readonly OrderContext _context;
        private readonly IOrderService _orderService;

        public OrdersController(OrderContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }


        // GET: api/Orders/GetCusomerOrders
        [HttpGet("GetCustomerOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetCustomerOrders(int customerId)
        {

            IEnumerable<Order> orders = await _orderService.GetCustomerOrders(customerId);

            if (orders == null)
            {
                return NotFound();
            }

            return orders.ToList();
        }

        // PUT: api/Orders
        [HttpPut]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            await _orderService.UpdateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }


        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            try
            {
                await _orderService.CancelOrder(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            
        }



    }
}
