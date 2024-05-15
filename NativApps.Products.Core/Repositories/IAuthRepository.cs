using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Repositories;

/// <summary>
/// Define la interfaz para un repositorio de autenticación.
/// </summary>
public interface IAuthRepository
{
    /// <summary>
    /// Valida las credenciales de inicio de sesión del usuario.
    /// </summary>
    /// <param name="userLogin">Las credenciales de inicio de sesión del usuario.</param>
    /// <returns>El usuario validado si las credenciales son correctas, de lo contrario, null.</returns>
    User? ValidateUser(User userLogin);
}
