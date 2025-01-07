using BankApp.Domain.DTOs;

namespace BankApp.Core.Interfaces
{
    public interface ILoanService
    {
        public Task<int> AddLoanAsync(LoanDTO loanDto);
    }
}
