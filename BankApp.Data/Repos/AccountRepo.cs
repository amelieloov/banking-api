using BankApp.Data.Interfaces;
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

        public async Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int userId)
        {
            var param = new DynamicParameters();
            param.Add("@UserId", userId);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                var accounts = await db.QueryAsync<Account, AccountType, Account>("GetAccountsForCustomer", (a, at) =>
                {
                    a.AccountType = at;
                    return a;
                },
                param, splitOn: "AccountTypeId", commandType: CommandType.StoredProcedure);

                return accounts;
            }
        }

        public async Task AddAccountAsync(int userId, Account account)
        {
            var param = new DynamicParameters();
            param.Add("@userId", userId);
            param.Add("@Frequency", account.Frequency);
            param.Add("@AccountTypeId", account.AccountTypeId);
            param.Add("@AccountId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                await db.ExecuteAsync("AddAccount", param, commandType: CommandType.StoredProcedure);
            }
        }

        //public async Task<int> GetCustomerId(int userId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", userId);

        //    using(IDbConnection db = _dbContext.GetConnection())
        //    {
        //        var id = await db.QuerySingleOrDefaultAsync<int>("GetCustomerId", param, commandType: CommandType.StoredProcedure);
        //        return id;
        //    }
        //}
    }
}
