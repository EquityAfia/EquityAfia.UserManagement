using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;

public class UserType
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string TypeName { get; set; }

    // Navigation property for the related PractitionerTypes
    public ICollection<PractitionerType> PractitionerTypes { get; set; } = new List<PractitionerType>();
}
