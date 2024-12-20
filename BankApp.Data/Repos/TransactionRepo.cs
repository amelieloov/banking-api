using BankApp.Data.Interfaces;
using BankApp.Domain.Models;
using Dapper;
using System.Data;

namespace BankApp.Data.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly IBankAppDBContext _dbContext;

        public TransactionRepo(IBankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int MakeTransfer(Transaction transaction)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", transaction.AccountId);
            param.Add("@DestAccountId", transaction.DestAccountId);
            param.Add("@Amount", transaction.Amount);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                return db.Execute("MakeTransfer", param, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Transaction> GetTransactionsForAccount(int accountId)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", accountId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                return db.Query<Transaction>("GetTransactionsForAccount", param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public decimal GetAccountBalance(int accountId)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", accountId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                return db.Query<decimal>("GetAccountBalance", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}
