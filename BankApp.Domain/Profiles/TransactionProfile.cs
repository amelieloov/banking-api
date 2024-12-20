using AutoMapper;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionDTO, Transaction>();
            CreateMap<Transaction, TransactionReadDTO>();
        }
    }
}
