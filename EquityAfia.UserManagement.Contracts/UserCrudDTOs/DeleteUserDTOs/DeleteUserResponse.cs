using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.UserCrudDTOs.DeleteUserDTOs
{
    public class DeleteUserResponse
    {
        public string Message { get; set; }
        public string? IdNumber { get; set; }
        public string? Email { get; set; }
    }
}
