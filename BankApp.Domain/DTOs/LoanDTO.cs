namespace BankApp.Domain.DTOs
{
    public class LoanDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}
