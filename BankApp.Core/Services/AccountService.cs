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

        public List<AccountReadDTO> GetAccountsForCustomer(int userId)
        {
            var customerId = _repo.GetCustomerId(userId);
            var accounts = _repo.GetAccountsForCustomer(customerId);

            List<AccountReadDTO> accountReadDtos = new List<AccountReadDTO>();

            foreach (var account in accounts)
            {
                accountReadDtos.Add(_mapper.Map<AccountReadDTO>(account));
            }

            return accountReadDtos;
        }

        public void AddAccount(int userId, AccountCreateDTO accountDto)
        {
            //check if username exists etc
            //_repo.GetAccountByUsername(account.Username);
            var customerId = _repo.GetCustomerId(userId);

            var account = _mapper.Map<Account>(accountDto);
            account.Created = DateTime.Now;
            account.Balance = 0;

            _repo.AddAccount(customerId, account);
        }
    }
}
