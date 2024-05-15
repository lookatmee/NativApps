namespace ProductManagementAPI.Dtos;

/// <summary>
/// Clase que representa la respuesta del usuario.
/// </summary>
public class UserResponseDto
{
    /// <summary>
    /// Nombre de usuario.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Rol del usuario.
    /// </summary>
    public string Role { get; set; }
}