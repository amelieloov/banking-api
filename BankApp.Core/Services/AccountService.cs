using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _repo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountReadDTO>> GetAccountsForCustomerAsync(int userId)
        {
            var accounts = await _repo.GetAccountsForCustomerAsync(userId);

            List<AccountReadDTO> accountReadDtos = new List<AccountReadDTO>();

            foreach (var account in accounts)
            {
                accountReadDtos.Add(_mapper.Map<AccountReadDTO>(account));
            }

            return accountReadDtos;
        }

        public async Task<int> AddAccountAsync(int userId, AccountCreateDTO accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            return await _repo.AddAccountAsync(userId, account);
        }
    }
}
