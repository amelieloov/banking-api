using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ITransactionRepo
    {
        public int MakeTransfer(Transaction transaction);
        public List<Transaction> GetTransactionsForAccount(int accountId);
        public decimal GetAccountBalance(int accountId);
    }
}
