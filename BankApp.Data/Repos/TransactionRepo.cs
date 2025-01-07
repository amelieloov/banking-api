using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
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

        public async Task<TransactionResultDTO> MakeTransferAsync(Transaction transaction)
        {
            var param = new DynamicParameters();
            param.Add("@DebitAccountId", transaction.AccountId);
            param.Add("@CreditAccountId", transaction.DestAccountId);
            param.Add("@Amount", transaction.Amount);
            param.Add("@DebitTransactionId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@CreditTransactionId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                await db.ExecuteAsync("MakeTransfer", param, commandType: CommandType.StoredProcedure);

                return new TransactionResultDTO
                {
                    DebitTransactionId = param.Get<int>("@DebitTransactionId"),
                    CreditTransactionId = param.Get<int>("@CreditTransactionId")
                };
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int accountId)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", accountId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                var transactions = await db.QueryAsync<Transaction>("GetTransactionsForAccount", param, commandType: CommandType.StoredProcedure);
                return transactions;
            }
        }

        public async Task<decimal> GetAccountBalanceAsync(int accountId)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", accountId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                decimal balance = await db.QuerySingleOrDefaultAsync<decimal>("GetAccountBalance", param, commandType: CommandType.StoredProcedure);
                return balance;
            }
        }
    }
}
