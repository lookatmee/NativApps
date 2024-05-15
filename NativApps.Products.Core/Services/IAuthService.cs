using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Services;

public interface IAuthService
{
    User? ValidateUser(User userLogin);
}
