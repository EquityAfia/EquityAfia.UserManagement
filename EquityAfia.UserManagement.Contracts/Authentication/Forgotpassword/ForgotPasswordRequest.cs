using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
