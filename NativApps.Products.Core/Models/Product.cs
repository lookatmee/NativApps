namespace NativApps.Products.Core.Models;

/// <summary>
/// Representa un producto.
/// </summary>
public class Product
{
    /// <summary>
    /// Obtiene o establece el identificador único del producto.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador único de la categoría a la que pertenece el producto.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre del producto.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece la descripción del producto.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Obtiene o establece el precio del producto.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Obtiene o establece la cantidad disponible del producto.
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// Obtiene o establece la categoría a la que pertenece el producto.
    /// </summary>
    public Category? Category { get; set; }
}
