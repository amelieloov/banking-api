using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<CustomerCreateResultDTO> AddCustomerAsync(Customer customer, User user);
    }
}
