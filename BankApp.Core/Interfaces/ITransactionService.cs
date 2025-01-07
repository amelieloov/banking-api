using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface ITransactionService
    {
        public Task<List<TransactionReadDTO>> GetTransactionsForAccountAsync(int userId, int accountId);
        public Task<TransactionResultDTO> MakeTransferAsync(int userId, TransactionDTO transactionDto);
    }
}
