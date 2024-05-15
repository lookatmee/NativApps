using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Repositories;

namespace NativApps.Products.Data.Repositories;

/// <summary>
/// Repositorio de productos que implementa la interfaz IProductRepository.
/// </summary>
public class ProductRepository : IProductRepository
{
    /// <summary>
    /// Contexto de la base de datos utilizado para acceder a los datos de productos.
    /// </summary>
    public ProductDBContext DBContext { get; }

    /// <summary>
    /// Constructor del repositorio de productos.
    /// </summary>
    /// <param name="dBContext">Contexto de la base de datos.</param>
    public ProductRepository(ProductDBContext dBContext)
    {
        DBContext = dBContext;
    }

    /// <summary>
    /// Agrega un nuevo producto a la base de datos.
    /// </summary>
    /// <param name="product">Producto a agregar.</param>
    public async Task AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        await DBContext.Products.AddAsync(product);
        await DBContext.SaveChangesAsync();
    }

    /// <summary>
    /// Actualiza un producto existente en la base de datos.
    /// </summary>
    /// <param name="product">Producto actualizado.</param>
    public async Task UpdateAsync(Product product)
    {
        var existingProduct = await DBContext.Products.FindAsync(product.Id);
        if (existingProduct != null)
        {
            DBContext.Entry(existingProduct).CurrentValues.SetValues(product);
            await DBContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Elimina un producto de la base de datos.
    /// </summary>
    /// <param name="id">ID del producto a eliminar.</param>
    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            DBContext.Products.Remove(product);
            await DBContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Obtiene todos los productos de la base de datos.
    /// </summary>
    /// <returns>Una colección de productos.</returns>
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await DBContext.Products.Include(x => x.Category).ToListAsync();
        return products;
    }

    /// <summary>
    /// Obtiene un producto por su ID de la base de datos.
    /// </summary>
    /// <param name="id">ID del producto.</param>
    /// <returns>El producto encontrado o null si no se encuentra.</returns>
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await DBContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        return product;
    }

    /// <summary>
    /// Busca productos por su nombre en la base de datos.
    /// </summary>
    /// <param name="name">Nombre del producto a buscar.</param>
    /// <returns>Una colección de productos encontrados.</returns>
    public async Task<IEnumerable<Product>> SearchAsync(string name)
    {
        var products = await DBContext.Products.Include(x => x.Category).Where(x => x.Name == name).ToListAsync();
        return products;
    }

    /// <summary>
    /// Busca productos por su precio en la base de datos.
    /// </summary>
    /// <param name="minPrice">Precio mínimo del producto.</param>
    /// <param name="maxPrice">Precio máximo del producto.</param>
    /// <returns>Una colección de productos encontrados.</returns>
    public async Task<IEnumerable<Product>> SearchAsync(decimal? minPrice, decimal? maxPrice)
    {
        var products = await DBContext.Products.Include(x => x.Category).Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToListAsync();
        return products;
    }
}
