using NativApps.Products.Core.Args;
using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Product>> SearchAsync(FilterSearch filterSearch);
}
