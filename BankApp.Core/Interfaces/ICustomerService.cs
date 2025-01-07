using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerCreateResultDTO> AddCustomerAsync(CustomerDTO customer, UserDTO userDto);
    }
}
