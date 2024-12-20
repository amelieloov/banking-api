namespace BankApp.Domain.DTOs
{
    public class TransactionDTO
    {
        public int AccountId { get; set; }
        public int DestAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
