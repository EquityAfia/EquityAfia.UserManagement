using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.Events
{
    public class UserRegistered
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
