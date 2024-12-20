using BankApp.Domain.Models;
using System.Collections;

namespace BankApp.Data.Interfaces
{
    public interface ITransactionRepo
    {
        public Task MakeTransferAsync(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int accountId);
        public Task<decimal> GetAccountBalanceAsync(int accountId);
    }
}
