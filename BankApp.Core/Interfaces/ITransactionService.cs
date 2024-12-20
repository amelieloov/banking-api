using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface ITransactionService
    {
        public Task<List<TransactionReadDTO>> GetTransactionsForAccountAsync(int accountId);
        public Task MakeTransferAsync(TransactionDTO transactionDto);
    }
}
