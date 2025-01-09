using BankApp.Api.Extensions;
using BankApp.Core.Interfaces;
using BankApp.Domain.Profiles;
using BankApp.Core.Services;
using BankApp.Data.DataModels;
using BankApp.Data.Interfaces;
using BankApp.Data.Repos;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(TransactionProfile).Assembly, typeof(AccountProfile).Assembly, typeof(UserProfile).Assembly, typeof(LoanProfile).Assembly, typeof(CustomerProfile).Assembly);
builder.Services.AddControllers();
builder.Services.AddSwaggerExtended();

builder.Services.AddSingleton<IBankAppDBContext, BankAppDBContext>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILoanRepo, LoanRepo>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuth();

var app = builder.Build();

app.UseSwaggerExtended();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
