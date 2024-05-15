using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NativApps.Products.Core.Models;

/// <summary>
/// Representa un usuario.
/// </summary>
public class User
{
    /// <summary>
    /// Obtiene o establece el identificador único del usuario.
    /// </summary>
    [Key]
    public string UserId { get; set; } = null!;

    /// <summary>
    /// Obtiene o establece el identificador único del rol al que pertenece el usuario.
    /// </summary>
    [ForeignKey("Role")]
    public Guid RolId { get; set; }

    /// <summary>
    /// Obtiene o establece la contraseña del usuario.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Obtiene o establece el rol al que pertenece el usuario.
    /// </summary>
    public Role? Role { get; set; }
}