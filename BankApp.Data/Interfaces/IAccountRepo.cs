using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface IAccountRepo
    {
        public Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int customerId);
        public Task<int> AddAccountAsync(int customerId, Account account);
    }
}
