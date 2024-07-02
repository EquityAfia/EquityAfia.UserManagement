using EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Application.Authentication.Commands.ResetPassword;
using EquityAfia.UserManagement.Application.Authentication.Queries.LogIn;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.DeleteUser;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser;
using EquityAfia.UserManagement.Application.UserCRUD.Queries.GetAllUsers;
using EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.DeleteRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.UpdateRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Queries.GetRoles;
using EquityAfia.UserManagement.Application.UserTypesManagement.Commands.AddUserType;
using EquityAfia.UserManagement.Application.UserTypesManagement.Commands.DeleteUserType;
using EquityAfia.UserManagement.Application.UserTypesManagement.Commands.UpdateUserType;
using EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes;
using EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword;
using EquityAfia.UserManagement.Contracts.Authentication.Login;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using EquityAfia.UserManagement.Contracts.Authentication.ResetPassword;
using EquityAfia.UserManagement.Contracts.UserCRUD.DeleteUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Infrastructure.Authentication;
using EquityAfia.UserManagement.Infrastructure.Data;
using EquityAfia.UserManagement.Infrastructure.Repositories;
using EquityAfia.UserManagement.Infrastructure.Repositories.UserReloAndTypeManagement;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
ConfigureLogging(builder);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR for handling commands and queries
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); // Adjust with appropriate AutoMapper profile or class

// Register command and query handlers
builder.Services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterResponse>, RegisterUserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<LoginQuery, LoginResponse>, LoginQueryHandler>();
builder.Services.AddTransient<IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>, ForgotPasswordCommandHandler>();
builder.Services.AddTransient<IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>, ResetPasswordCommandHandler>();

// User operations
builder.Services.AddTransient<IRequestHandler<GetUserQuery, GetUserResponse>, GetUserQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllUsersQuery, List<User>>, GetAllUsersQueryHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateUserCommand, UpdateUserResponse>, UpdateUserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteUserCommand, DeleteUserResponse>, DeleteUserCommandHandler>();

// User Roles operations
builder.Services.AddTransient<IRequestHandler<AddRoleCommand, UserRoleResponse>, AddRoleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateRoleCommand, UserRoleResponse>, UpdateRoleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteRoleCommand, UserRoleResponse>, DeleteRoleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetRoleQuery, List<Role>>, GetRoleQueryHandler>();

// User Types operations
builder.Services.AddTransient<IRequestHandler<GetUserTypeQuery, List<UserType>>, GetUserTypeQueryHandler>();
builder.Services.AddTransient<IRequestHandler<AddUserTypeCommand, UserTypeResponse>, AddUserTypeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateUserTypeCommand, UserTypeResponse>, UpdateUserTypeCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteUserTypeCommand, UserTypeResponse>, DeleteUserTypeCommandHandler>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IPractitionerTypeRepository, PractitionerTypeRepository>();
builder.Services.AddScoped<IPractitionerRepository, PractitionerRepository>();

// Register JwtSettings from appsettings.json
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
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Adjust if necessary
        };
    });

// MassTransit RabbitMQ configuration
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });

});

builder.Services.AddMassTransitHostedService();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
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
        loggingBuilder.ClearProviders();
        loggingBuilder.AddConsole();
    });
}
