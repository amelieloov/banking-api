using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankApp.Domain.Models;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetTransactionsForAccount(int accountId)
        {
            List<TransactionReadDTO> transactions = _service.GetTransactionsForAccount(accountId);

            return Ok(transactions);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult MakeTransfer(TransactionDTO transactionDto)
        {
            try
            {
                _service.MakeTransfer(transactionDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while making transfer.");
            }

            return Ok();
        }
    }
}
