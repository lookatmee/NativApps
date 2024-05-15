using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Data.Repositories;

/// <summary>
/// Repositorio de autenticación que implementa la interfaz IAuthRepository.
/// </summary>
public class AuthRepository : IAuthRepository
{
    /// <summary>
    /// Contexto de la base de datos utilizado para acceder a los datos de usuario.
    /// </summary>
    public ProductDBContext DBContext { get; }

    /// <summary>
    /// Constructor del repositorio de autenticación.
    /// </summary>
    /// <param name="dBContext">Contexto de la base de datos.</param>
    public AuthRepository(ProductDBContext dBContext)
    {
        DBContext = dBContext;
    }

    /// <summary>
    /// Valida las credenciales de un usuario.
    /// </summary>
    /// <param name="userLogin">Usuario y contraseña proporcionados para la autenticación.</param>
    /// <returns>El usuario validado si las credenciales son correctas, de lo contrario, null.</returns>
    public User? ValidateUser(User userLogin)
    {
        // Busca el usuario en la base de datos que coincida con el UserId y Password proporcionados
        var existingUser = DBContext.Users.Include(x => x.Role)
            .SingleOrDefault(x => x.UserId == userLogin.UserId && x.Password == userLogin.Password);

        // Devuelve el usuario si se encontró, de lo contrario, devuelve null
        return existingUser;
    }
}
