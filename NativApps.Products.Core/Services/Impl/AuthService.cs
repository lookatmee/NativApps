using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Core.Services.Impl;

/// <summary>
/// Implementación del servicio de autenticación.
/// </summary>
public class AuthService : IAuthService
{
    private IAuthRepository AuthRepository { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AuthService"/>.
    /// </summary>
    /// <param name="authRepository">El repositorio de autenticación utilizado por el servicio.</param>
    public AuthService(IAuthRepository authRepository)
    {
        AuthRepository = authRepository;
    }

    /// <summary>
    /// Valida las credenciales de inicio de sesión del usuario.
    /// </summary>
    /// <param name="userLogin">Las credenciales de inicio de sesión del usuario.</param>
    /// <returns>El usuario validado si las credenciales son correctas, de lo contrario, null.</returns>
    public User? ValidateUser(User userLogin)
    {
        return AuthRepository.ValidateUser(userLogin);
    }
}
