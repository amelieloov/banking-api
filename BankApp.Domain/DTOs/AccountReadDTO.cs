namespace BankApp.Domain.DTOs
{
    public class AccountReadDTO
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string TypeName { get; set; }
    }
}
