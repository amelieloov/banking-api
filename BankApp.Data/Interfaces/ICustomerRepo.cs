using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ICustomerRepo
    {
        public Task AddCustomerAsync(Customer customer, User user);
    }
}
