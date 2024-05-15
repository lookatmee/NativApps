using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Product>> SearchAsync(string name);
    Task<IEnumerable<Product>> SearchAsync(decimal? minPrice, decimal? maxPrice);
}
