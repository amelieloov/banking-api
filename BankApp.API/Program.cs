using AutoMapper;
using BankApp.Api.Extensions;
using BankApp.Core.Interfaces;
using BankApp.Core.Services;
using BankApp.Data.DataModels;
using BankApp.Data.Interfaces;
using BankApp.Data.Repos;
using BankApp.Domain.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(opt =>
//{
//    opt.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "https://localhost:7214/",
//        ValidAudience = "https://localhost:7214/",
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fkls5235k325bb25b23blb52352b35235b2b532knels"))
//    };
//});

var app = builder.Build();

app.UseSwaggerExtended();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
