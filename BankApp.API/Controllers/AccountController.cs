using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAccountsForCustomer()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            IEnumerable<AccountReadDTO> accounts = await _service.GetAccountsForCustomerAsync(userId);

            return Ok(accounts);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountCreateDTO accountDto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var accountId = await _service.AddAccountAsync(userId, accountDto);

            return Ok($"Account created with id {accountId}.");
        }
    }
}
