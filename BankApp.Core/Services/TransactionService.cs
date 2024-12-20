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

        public int MakeTransfer(TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            return _repo.MakeTransfer(transaction);
        }

        public List<TransactionReadDTO> GetTransactionsForAccount(int accountId)
        {
            var transactions = _repo.GetTransactionsForAccount(accountId);
            var transactionsDtos = new List<TransactionReadDTO>();

            foreach(var transaction in transactions)
            {
                transactionsDtos.Add(_mapper.Map<TransactionReadDTO>(transaction));
            }

            return transactionsDtos; 
        }
    }
}
