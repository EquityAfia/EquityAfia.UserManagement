using EquityAfia.UserManagement.Contracts.Authentication.Login;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Authentication.Queries.LogIn
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public LoginRequest LoginRequest { get; set; }

        public LoginQuery(LoginRequest user)
        {
            LoginRequest = user;
        }
    }
}
