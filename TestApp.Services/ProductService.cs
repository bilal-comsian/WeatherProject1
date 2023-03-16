using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testapp.Interfaces;
using Testapp.Model;
using TestApp.Services.Interfaces;

namespace TestApp.Services
{
    public class CustomerService: ICustomerService
    {
        public IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                await _unitOfWork.Customers.Add(customer);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            if (customerId > 0)
            {
                var productDetails = await _unitOfWork.Customers.GetById(customerId);
                if (productDetails != null)
                {
                    _unitOfWork.Customers.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            if (customerId > 0)
            {
                var customers = await _unitOfWork.Customers.GetById(customerId);
                if (customers != null)
                {
                    return customers;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var _customer = await _unitOfWork.Customers.GetById(customer.Id);
                if (_customer != null)
                {
                    _customer.Name = customer.Name;

                    _unitOfWork.Customers.Update(_customer);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
