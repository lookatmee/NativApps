namespace ProductManagementAPI.Dtos;

/// <summary>
/// Clase que representa los datos de inicio de sesión del usuario.
/// </summary>
public class UserLoginDto
{
    /// <summary>
    /// Nombre de usuario.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Contraseña del usuario.
    /// </summary>
    public string Password { get; set; }
}
