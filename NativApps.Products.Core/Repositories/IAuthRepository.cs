using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Repositories;

public interface IAuthRepository
{
    User? ValidateUser(User userLogin);
}
