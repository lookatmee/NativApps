namespace NativApps.Products.Core.Models;

/// <summary>
/// Representa una categoría de productos.
/// </summary>
public class Category
{
    /// <summary>
    /// Obtiene o establece el identificador único de la categoría.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre de la categoría.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece la descripción de la categoría.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de productos asociados a la categoría.
    /// </summary>
    public List<Product> Products { get; set; } = new List<Product>();
}
