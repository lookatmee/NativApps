using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Core.Services.Impl;

public class AuthService : IAuthService
{
    private IAuthRepository AuthRepository { get; }

    public AuthService(IAuthRepository authRepository)
    {
        AuthRepository = authRepository;
    }
    public User? ValidateUser(User userLogin)
    {
        return AuthRepository.ValidateUser(userLogin);
    }
}
