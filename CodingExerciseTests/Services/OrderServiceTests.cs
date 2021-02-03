using CodingExercise.DataAccess;
using CodingExercise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CodingExercise.Services.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        //	List all orders by customer endpoint
        //	Update order endpoint
        //	Cancel order endpoint

        private static DbContextOptions<OrderContext> GetOptions(string databaseName)
        {
            var builder = new DbContextOptionsBuilder<OrderContext>();
            builder.UseInMemoryDatabase(databaseName);
            return builder.Options;
        }

        private bool IsTheSame(Order order1, Order order2)
        {
            if 
                (
                order1.OrderId == order2.OrderId &&
                order1.CustomerId == order2.CustomerId &&
                order1.OrderDescription == order2.OrderDescription &&
                order1.Cost == order2.Cost
                )
                { return true; }
            else
            { return false; }
        }


        [TestMethod()]
        public async Task GetCustomerOrdersTest()
        {
            //ARRANGE
            var testOrder = new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDescription = "Some order",
                Cost = 1
            };
            
            using var context = new OrderContext(GetOptions(nameof(GetCustomerOrdersTest)));
            
            context.Orders.Add(testOrder);

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            //ACT
            var orders = await service.GetCustomerOrders(1);

            //ASSSERT
            Assert.IsTrue(orders.Any()); //Was able to retrieve orders
            //Assert.IsTrue(orders.Count() == 1); //Only returned the one order
            //Assert.IsTrue(IsTheSame(orders.FirstOrDefault(), testOrder)); //the orders are the same
        }

        [TestMethod()]
        public async Task UpdateOrderTest()
        {
            //ARRANGE
            var testOrder = new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDescription = "Some order",
                Cost = 1
            };

            using var context = new OrderContext(GetOptions(nameof(UpdateOrderTest)));

            context.Orders.Add(testOrder);

            await context.SaveChangesAsync();

            var service = new OrderService(context);

            //ACT
            string newDescription = "Some new description";
            Order changedOrder = await context.Orders.FindAsync(1);
            changedOrder.OrderDescription = newDescription;
            await service.UpdateOrder(changedOrder);

            //ASSSERT
            Assert.IsTrue(context.Orders.FindAsync(1).Result.OrderDescription == newDescription); //descriptions are the same
        }

        [TestMethod()]
        public async Task GetOrderTest()
        {
            //ARRANGE
            var testOrder = new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDescription = "Some order",
                Cost = 1
            };

            using var context = new OrderContext(GetOptions(nameof(GetOrderTest)));

            context.Orders.Add(testOrder);

            var service = new OrderService(context);

            //ACT
            Order order = await service.GetOrder(1);

            //ASSSERT
            Assert.IsTrue(order.OrderId == 1); //Was able to retrieve the order
        }

        [TestMethod()]
        public async Task CancelOrderTest()
        {
            //ARRANGE
            var testOrder = new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDescription = "Some order",
                Cost = 1
            };

            using var context = new OrderContext(GetOptions(nameof(CancelOrderTest)));

            context.Orders.Add(testOrder);

            var service = new OrderService(context);

            //ACT
            await service.CancelOrder(1);
            Order foundOrder = await context.Orders.FindAsync(1);

            //ASSSERT
            Assert.IsTrue(foundOrder is null); //Was unable to retrieve the order
        }
    }
}