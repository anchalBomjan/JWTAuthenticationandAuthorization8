using AuthenticationandAuthorizationJWTToken9.Data;
using AuthenticationandAuthorizationJWTToken9.Interface;
using AuthenticationandAuthorizationJWTToken9.Middleware;
using AuthenticationandAuthorizationJWTToken9.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployee,EmployeeRepository>();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<CustomExceptionFilter>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


