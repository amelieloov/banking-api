using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using Dapper;

namespace BankApp.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _repo;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task MakeTransferAsync(TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            await _repo.MakeTransferAsync(transaction);
        }

        public async Task<List<TransactionReadDTO>> GetTransactionsForAccountAsync(int accountId)
        {
            var transactions = await _repo.GetTransactionsForAccountAsync(accountId);
            var transactionsDtos = new List<TransactionReadDTO>();

            foreach(var transaction in transactions)
            {
                transactionsDtos.Add(_mapper.Map<TransactionReadDTO>(transaction));
            }

            return transactionsDtos; 
        }
    }
}
