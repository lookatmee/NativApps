using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NativApps.Products.Core.Models;

public class User
{
    [Key]
    public string UserId { get; set; } = null!;

    [ForeignKey("Role")]
    public Guid RolId { get; set; }
    public string? Password { get; set; }
    public Role? Role { get; set; }
    
}
