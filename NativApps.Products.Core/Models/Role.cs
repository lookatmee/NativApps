using System.ComponentModel.DataAnnotations;

namespace NativApps.Products.Core.Models;

/// <summary>
/// Representa un rol de usuario.
/// </summary>
public class Role
{
    /// <summary>
    /// Obtiene o establece el identificador único del rol.
    /// </summary>
    [Key]
    public Guid RolId { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre del rol.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de usuarios asociados al rol.
    /// </summary>
    public List<User> Users { get; set; } = new List<User>();
}