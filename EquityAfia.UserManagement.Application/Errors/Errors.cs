using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Errors
{
    public class Errors
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public Errors(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
