using System.ComponentModel.DataAnnotations;

namespace NativApps.Products.Core.Models;

public class Role
{
    [Key]
    public Guid RolId { get; set; }
    public string? Name { get; set; }
    public List<User> Users { get; set; } = new List<User>();
}
