
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Infrastructure.Data;
using EquityAfia.UserManagement.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and configure SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IRequestHandler<RegisterPractitionerCommand, Guid>, RegisterPractitionerCommandHandler>();

builder.Services.AddTransient<IRequestHandler<RegisterUserCommand, Guid>, RegisterUserCommandHandler>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
