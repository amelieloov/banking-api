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

        public int AddLoan(Loan loan)
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
                return db.Execute("AddLoanAndUpdateAccountBalance", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
