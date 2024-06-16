using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword
{
    public class ForgotPasswordResponse
    {
        public string Email { get; set; }
        public string ResetCode { get; set; }
    }
}
