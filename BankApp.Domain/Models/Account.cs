namespace BankApp.Domain.Models
{
    public class Account
    {
        public Account()
        {
        }

        public int AccountId { get; set; }
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public string Frequency { get; set; }

        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

    }
}