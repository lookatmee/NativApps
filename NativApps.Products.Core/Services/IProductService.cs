using NativApps.Products.Core.Args;
using NativApps.Products.Core.Models;

namespace NativApps.Products.Core.Services;

/// <summary>
/// Interfaz para el servicio de productos.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Obtiene todos los productos de manera asíncrona.
    /// </summary>
    Task<IEnumerable<Product>> GetAllAsync();

    /// <summary>
    /// Obtiene un producto por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador del producto.</param>
    /// <returns>El producto encontrado o null si no se encuentra.</returns>
    Task<Product?> GetByIdAsync(Guid id);

    /// <summary>
    /// Agrega un nuevo producto de manera asíncrona.
    /// </summary>
    /// <param name="product">El producto a agregar.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Actualiza un producto existente de manera asíncrona.
    /// </summary>
    /// <param name="product">El producto actualizado.</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Elimina un producto por su identificador de manera asíncrona.
    /// </summary>
    /// <param name="id">El identificador del producto a eliminar.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Busca productos de manera asíncrona según los criterios especificados en <paramref name="filterSearch"/>.
    /// </summary>
    /// <param name="filterSearch">Los criterios de búsqueda.</param>
    /// <returns>Una colección de productos que coinciden con los criterios de búsqueda.</returns>
    Task<IEnumerable<Product>> SearchAsync(FilterSearch filterSearch);
}