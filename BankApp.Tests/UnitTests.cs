using BankApp.Data.Interfaces;
using BankApp.Data.Repos;
using BankApp.Domain.Models;
using Dapper;
using Microsoft.Identity.Client;
using Moq;
using Moq.Dapper;
using System.Data;

namespace BankApp.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(12000, 12, 1000)]
        [InlineData(6000, 0, 1000)]
        [InlineData(-16000, 5, 3200)]
        public void TestCalculatePayments_return_correct_value(decimal amount, decimal duration, decimal payments)
        {
            var result = amount / duration;

            Assert.Equal(payments, result);
        }

        [Fact]
        public async Task TestGetTransactionsForAccountAsync_returns_correct_transactions()
        {
            var expectedTransactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, AccountId = 111, Amount = -10000.00m },
                new Transaction { TransactionId = 2, AccountId = 111, Amount = 5000.00m },
                new Transaction { TransactionId = 3, AccountId = 111, Amount = 20000.00m },
            };

            var mockDbContext = new Mock<IBankAppDBContext>();
            var mockDbConnection = new Mock<IDbConnection>();

            mockDbContext.Setup(c => c.GetConnection()).Returns(mockDbConnection.Object);

            mockDbConnection.SetupDapperAsync(c => c.QueryAsync<Transaction>(
                "GetTransactionsForAccount",
                It.IsAny<DynamicParameters>(),
                null,
                null,
                CommandType.StoredProcedure
            )).ReturnsAsync(expectedTransactions);

            var repo = new TransactionRepo(mockDbContext.Object);

            var result = await repo.GetTransactionsForAccountAsync(111);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task TestGetAccountsForCustomer_returns_correct_accounts()
        {
            List<Account> expectedAccounts = new List<Account>()
            {
                new Account
                {
                    AccountId = 1,
                    Balance = 30000.00m,
                    AccountType = new AccountType {AccountTypeId = 1, TypeName = "Standard transaction account"}
                },

                new Account
                {
                    AccountId = 2,
                    Balance = 20000.00m,
                    AccountType = new AccountType {AccountTypeId = 2, TypeName = "Savings account"}
                }
            };

            var mockDbContext = new Mock<IBankAppDBContext>();
            var mockDbConnection = new Mock<IDbConnection>();

            mockDbContext.Setup(c => c.GetConnection()).Returns(mockDbConnection.Object);

            mockDbConnection.SetupDapperAsync(db => db.QueryAsync<Account, AccountType, Account>(
                "GetAccountsForCustomer",
                It.IsAny<Func<Account, AccountType, Account>>(),
                It.IsAny<DynamicParameters>(),
                (IDbTransaction?)null,
                true,
                It.IsAny<string>(),
                null,
                CommandType.StoredProcedure)).ReturnsAsync(expectedAccounts);

            var repo = new AccountRepo(mockDbContext.Object);

            var result = await repo.GetAccountsForCustomerAsync(1);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(expectedAccounts.First().AccountId, result.First().AccountId);
        }
    }
}