using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> GetTransactionsForAccount(int accountId)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            List<TransactionReadDTO> transactions = new List<TransactionReadDTO>();

            try
            {
                transactions = await _service.GetTransactionsForAccountAsync(userId, accountId);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid account ID.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while getting transfers.");
            }

            return Ok(transactions);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> MakeTransfer(TransactionDTO transactionDto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            try
            {
                var transactionResult = await _service.MakeTransferAsync(userId, transactionDto);
                return Ok(new { result = transactionResult });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid account ID.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while making transfer.");
            }
        }
    }
}
