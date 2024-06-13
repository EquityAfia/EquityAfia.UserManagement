using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string Location { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool Is2FAEnabled { get; set; } = false;
        public bool IsAccountVerified { get; set; } = false;
        public bool IsInitialPasswordChanged { get; set; } = false;
        public bool IsPasswordExpired { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public string? ResetToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Navigation property for UserRoles
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
