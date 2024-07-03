using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.UserCrudDTOs.UpdateUserDTOs
{
    public class UpdateUserResponse
    {
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}
