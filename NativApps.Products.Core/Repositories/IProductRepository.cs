using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Repositories;

/// <summary>
/// Define la interfaz para un repositorio de productos.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Obtiene todos los productos de forma asincrónica.
    /// </summary>
    Task<IEnumerable<Product>> GetAllAsync();

    /// <summary>
    /// Obtiene un producto por su identificador de forma asincrónica.
    /// </summary>
    /// <param name="id">El identificador único del producto.</param>
    Task<Product?> GetByIdAsync(Guid id);

    /// <summary>
    /// Agrega un nuevo producto de forma asincrónica.
    /// </summary>
    /// <param name="product">El producto que se va a agregar.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Actualiza un producto de forma asincrónica.
    /// </summary>
    /// <param name="product">El producto que se va a actualizar.</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Elimina un producto por su identificador de forma asincrónica.
    /// </summary>
    /// <param name="id">El identificador único del producto que se va a eliminar.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Busca productos por su nombre de forma asincrónica.
    /// </summary>
    /// <param name="name">El nombre del producto a buscar.</param>
    Task<IEnumerable<Product>> SearchAsync(string name);

    /// <summary>
    /// Busca productos por rango de precio de forma asincrónica.
    /// </summary>
    /// <param name="minPrice">El precio mínimo del producto.</param>
    /// <param name="maxPrice">El precio máximo del producto.</param>
    Task<IEnumerable<Product>> SearchAsync(decimal? minPrice, decimal? maxPrice);
}
