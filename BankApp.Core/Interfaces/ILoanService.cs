using BankApp.Domain.DTOs;

namespace BankApp.Core.Interfaces
{
    public interface ILoanService
    {
        public int AddLoan(LoanDTO loanDto);
    }
}
