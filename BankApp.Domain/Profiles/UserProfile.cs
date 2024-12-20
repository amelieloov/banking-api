using AutoMapper;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
