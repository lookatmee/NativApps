using NativApps.Products.Core.Args;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Core.Services.Impl;

/// <summary>
/// Implementación del servicio de productos.
/// </summary>
public class ProductService : IProductService
{
    private IProductRepository ProductRepository { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ProductService"/>.
    /// </summary>
    /// <param name="productRepository">El repositorio de productos utilizado por el servicio.</param>
    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Product product)
    {
        await ProductRepository.AddAsync(product);
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(Product product)
    {
        await ProductRepository.UpdateAsync(product);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        await ProductRepository.DeleteAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await ProductRepository.GetAllAsync();
    }

    /// <inheritdoc/>
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await ProductRepository.GetByIdAsync(id);
    }

    /// <inheritdoc/>
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
