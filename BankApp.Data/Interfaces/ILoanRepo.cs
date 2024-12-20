using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface ILoanRepo
    {
        public Task AddLoanAsync(Loan loan);
    }
}
