using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Application.Authentication.Queries.LogIn;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.Authentication;
using EquityAfia.UserManagement.Infrastructure.Authentication;
using EquityAfia.UserManagement.Infrastructure.Data;
using EquityAfia.UserManagement.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add logging configuration
ConfigureLogging(builder);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and configure SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Register AutoMapper for services from the executing assembly
builder.Services.AddAutoMapper(typeof(RegisterUserCommandHandler)); 


builder.Services.AddTransient<IRequestHandler<RegisterPractitionerCommand, RegisterResponse>, RegisterPractitionerCommandHandler>();
builder.Services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterResponse>, RegisterUserCommandHandler>();

builder.Services.AddTransient<IRequestHandler<LoginQuery, LoginResponse>, LoginQueryHandler>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();


// Register JwtSettings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Register JwtTokenGenerator
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidIssuer = jwtSettings.Issuer, // Set valid issuer
            ValidateAudience = false,
            ValidAudience = jwtSettings.Audience, // Set valid audience
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ValidateLifetime = false,
            ClockSkew = TimeSpan.Zero // Adjust if necessary
        };
    });

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

// Configure logging
void ConfigureLogging(WebApplicationBuilder builder)
{
    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders(); // Clear the default logging providers
        loggingBuilder.AddConsole(); 

    });
}
