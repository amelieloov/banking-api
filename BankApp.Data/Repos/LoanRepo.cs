using BankApp.Data.Interfaces;
using BankApp.Domain.Models;
using Dapper;
using System.Data;

namespace BankApp.Data.Repos
{
    public class LoanRepo : ILoanRepo
    {
        private readonly IBankAppDBContext _dbContext;

        public LoanRepo(IBankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            var param = new DynamicParameters();
            param.Add("@AccountId", loan.AccountId);
            param.Add("@Date", loan.Date);
            param.Add("@Amount", loan.Amount);
            param.Add("@Duration", loan.Duration);
            param.Add("@Payments", loan.Payments);
            param.Add("@Status", loan.Status);

            using(IDbConnection db = _dbContext.GetConnection())
            {
                await db.ExecuteAsync("MakeLoan", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
