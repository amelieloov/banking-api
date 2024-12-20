using AutoMapper;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanDTO, Loan>();
        }
    }
}
