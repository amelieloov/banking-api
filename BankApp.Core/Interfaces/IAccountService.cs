using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<AccountReadDTO>> GetAccountsForCustomerAsync(int customerId);
        public Task<int> AddAccountAsync(int customerId, AccountCreateDTO accountDto);
    }
}
