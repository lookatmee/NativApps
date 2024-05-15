using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Data.Repositories;

public class AuthRepository : IAuthRepository
{
    public ProductDBContext DBContext { get; }

    public AuthRepository(ProductDBContext dBContext)
    {
        DBContext = dBContext;
    }

    public User? ValidateUser(User userLogin)
    {
        var existingUser = DBContext.Users.Include(x => x.Role).SingleOrDefault(x => x.UserId == userLogin.UserId && x.Password == userLogin.Password);
        if (existingUser is not null)
        {
            return existingUser;
        }
        else { return null; }
    }
}
