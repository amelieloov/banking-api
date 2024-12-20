namespace BankApp.Domain.DTOs
{
    public class TransactionReadDTO
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Operation { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
