using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using Dapper;
using System.Data;

namespace BankApp.Data.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly IBankAppDBContext _dbContext;

        public AccountRepo(IBankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Account> GetAccountsForCustomer(int customerId)
        {
            var param = new DynamicParameters();
            param.Add("@CustomerId", customerId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                return db.Query<Account, AccountType, Account>("GetAccountsForCustomer", (a, at) =>
                {
                    a.AccountType = at;
                    return a;
                },
                param, splitOn: "AccountTypeId", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int AddAccount(int customerId, Account account)
        {
            var param = new DynamicParameters();
            param.Add("@CustomerId", customerId);
            param.Add("@Frequency", account.Frequency);
            param.Add("@Created", account.Created);
            param.Add("@Balance", account.Balance);
            param.Add("@AccountTypeId", account.AccountTypeId);
            param.Add("@AccountId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                return db.Execute("AddAccount", param, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetCustomerId(int userId)
        {
            var param = new DynamicParameters();
            param.Add("@UserId", userId);

            using(IDbConnection db = _dbContext.GetConnection())
            {
                return db.Query<int>("GetCustomerId", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}
