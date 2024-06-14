using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Contracts.UserCRUD.GetUser
{
    public class GetUserRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string? IdNumber { get; set; }
    }
}
