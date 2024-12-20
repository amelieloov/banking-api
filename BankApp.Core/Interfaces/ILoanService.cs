using BankApp.Domain.DTOs;

namespace BankApp.Core.Interfaces
{
    public interface ILoanService
    {
        public Task AddLoanAsync(LoanDTO loanDto);
    }
}
