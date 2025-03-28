using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddLoan(LoanDTO loanDto)
        {
            if (loanDto.Amount <= 0 || loanDto.Duration <= 0)
            {
                return BadRequest("Duration and amount must be higher than 0.");
            }

            var loanId = await _service.AddLoanAsync(loanDto);

            return Ok(new { id = loanId});
        }
    }
}
