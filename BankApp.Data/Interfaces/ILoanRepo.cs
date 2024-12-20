using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ILoanRepo
    {
        public int AddLoan(Loan loan);
    }
}
