using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface IAccountRepo
    {
        public List<Account> GetAccountsForCustomer(int customerId);
        public int AddAccount(int customerId, Account account);
        public int GetCustomerId(int userId);
    }
}
