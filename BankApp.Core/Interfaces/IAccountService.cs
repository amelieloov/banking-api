using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface IAccountService
    {
        public List<AccountReadDTO> GetAccountsForCustomer(int customerId);
        public void AddAccount(int customerId, AccountCreateDTO accountDto);
    }
}
