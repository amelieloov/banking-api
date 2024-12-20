using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ICustomerRepo
    {
        public int AddCustomer(Customer customer, User user);
    }
}
