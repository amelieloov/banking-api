using AutoMapper;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
