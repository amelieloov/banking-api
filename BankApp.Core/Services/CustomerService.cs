using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerCreateResultDTO> AddCustomerAsync(CustomerDTO customerDto, UserDTO userDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return await _repo.AddCustomerAsync(customer, user);
        }
    }
}
