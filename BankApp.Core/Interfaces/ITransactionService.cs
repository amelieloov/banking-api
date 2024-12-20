using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface ITransactionService
    {
        public List<TransactionReadDTO> GetTransactionsForAccount(int accountId);
        public int MakeTransfer(TransactionDTO transactionDto);
    }
}
