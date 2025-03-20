using BankApp.Core.Interfaces;
using BankApp.Core.Services;
using BankApp.Data.DataModels;
using BankApp.Data.Interfaces;
using BankApp.Data.Repos;

namespace BankApp.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            // Register database context
            services.AddSingleton<IBankAppDBContext, BankAppDBContext>();

            // Register repositories
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ILoanRepo, LoanRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<IUserRepo, UserRepo>();

            // Register services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }

}
