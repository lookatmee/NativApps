using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Services;

/// <summary>
/// Interfaz para el servicio de autenticación.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Valida las credenciales del usuario.
    /// </summary>
    /// <param name="userLogin">El usuario y contraseña para validar.</param>
    /// <returns>El usuario si las credenciales son válidas; de lo contrario, null.</returns>
    User? ValidateUser(User userLogin);
}
