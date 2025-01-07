using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _repo;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepo repo, IMapper mapper, IAccountService accountService)
        {
            _repo = repo;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<TransactionResultDTO> MakeTransferAsync(int userId, TransactionDTO transactionDto)
        {
            var isValidAccount = await IsValidAccount(userId, transactionDto.AccountId);

            if (!isValidAccount)
                throw new UnauthorizedAccessException();

            var transaction = _mapper.Map<Transaction>(transactionDto);

            return await _repo.MakeTransferAsync(transaction);
        }

        public async Task<List<TransactionReadDTO>> GetTransactionsForAccountAsync(int userId, int accountId)
        {
            var isValidAccount = await IsValidAccount(userId, accountId);

            if (!isValidAccount)
                throw new UnauthorizedAccessException();

            var transactions = await _repo.GetTransactionsForAccountAsync(accountId);
            var transactionsDtos = new List<TransactionReadDTO>();

            foreach(var transaction in transactions)
            {
                transactionsDtos.Add(_mapper.Map<TransactionReadDTO>(transaction));
            }

            return transactionsDtos; 
        }

        public async Task<bool> IsValidAccount(int userId, int accountId)
        {
            var accounts = await _accountService.GetAccountsForCustomerAsync(userId);
            List<AccountReadDTO> accountList = accounts.ToList();

            var isValid = accountList.Any(a => a.AccountId == accountId);

            if (isValid)
                return true;
            else
                return false;
        }
    }
}
