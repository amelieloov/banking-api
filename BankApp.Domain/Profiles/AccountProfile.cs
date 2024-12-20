using AutoMapper;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountCreateDTO, Account>();

            CreateMap<Account, AccountReadDTO>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.AccountType.TypeName));
        }
    }
}
