using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface ICustomerService
    {
        public void AddCustomer(CustomerDTO customer, UserDTO userDto);
    }
}
