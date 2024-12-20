namespace BankApp.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public DateTime Birthday { get; set; }
        public string? TelephoneCountryCode { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? EmailAddress { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
