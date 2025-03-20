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

builder.Services.AddApplicationDependencies();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

app.UseSwaggerExtended();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
