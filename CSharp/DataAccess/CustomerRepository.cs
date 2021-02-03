using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.DataAccess
{
    
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomer(int customerId);
    }


    public class CustomerRepository : ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
