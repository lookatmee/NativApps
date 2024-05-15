using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Data.Repositories;

public class ProductRepository : IProductRepository
{
    public ProductDBContext DBContext { get; }

    public ProductRepository(ProductDBContext dBContext)
    {
        DBContext = dBContext;
    }
    public async Task AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        await DBContext.Products.AddAsync(product);
        await DBContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var existingProduct = await DBContext.Products.FindAsync(product.Id);
        if (existingProduct != null)
        {
            DBContext.Entry(existingProduct).CurrentValues.SetValues(product);
            await DBContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            DBContext.Products.Remove(product);
            await DBContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await DBContext.Products.Include(x => x.Category).ToListAsync();
        return products;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await DBContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        return product;
    }

    public async Task<IEnumerable<Product>> SearchAsync(string name)
    {
        var products = await DBContext.Products.Include(x => x.Category).Where(x => x.Name == name).ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> SearchAsync(decimal? minPrice, decimal? maxPrice)
    {
        var products = await DBContext.Products.Include(x => x.Category).Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToListAsync();
        return products;
    }
}
