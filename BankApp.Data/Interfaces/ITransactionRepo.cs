using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using System.Collections;

namespace BankApp.Data.Interfaces
{
    public interface ITransactionRepo
    {
        public Task<TransactionResultDTO> MakeTransferAsync(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int accountId);
        public Task<decimal> GetAccountBalanceAsync(int accountId);
    }
}
