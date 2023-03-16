using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testapp.Model;

namespace TestApp.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int customerId);

        Task<bool> UpdateCustomer(Customer Customer);

        Task<bool> DeleteCustomer(int customerId);
    }
}
