using NativApps.Products.Core.Args;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Core.Services.Impl;

public class ProductService : IProductService
{
    private IProductRepository ProductRepository { get; }
    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }
    public async Task AddAsync(Product product)
    {
        await ProductRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await ProductRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await ProductRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await ProductRepository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await ProductRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> SearchAsync(FilterSearch filterSearch)
    {
        if (filterSearch is null)
        {
            throw new ArgumentNullException(nameof(filterSearch));
        }

        if (!string.IsNullOrEmpty(filterSearch.Name))
        {
            return await ProductRepository.SearchAsync(filterSearch.Name);
        }
        else
        {
            return await ProductRepository.SearchAsync(filterSearch.MinPrice, filterSearch.MaxPrice);
        }
    }
}
