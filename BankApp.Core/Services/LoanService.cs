using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepo _repo;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddLoanAsync(LoanDTO loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            loan.Date = DateTime.Now;
            loan.Payments = loan.Amount / loan.Duration;

            await _repo.AddLoanAsync(loan);
        }
    }
}
