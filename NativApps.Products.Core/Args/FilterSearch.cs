namespace NativApps.Products.Core.Args;

/// <summary>
/// Representa los criterios de búsqueda para filtrar productos.
/// </summary>
public class FilterSearch
{
    /// <summary>
    /// Obtiene o establece el nombre del producto a buscar.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece el precio mínimo del producto a buscar.
    /// </summary>
    public decimal? MinPrice { get; set; }

    /// <summary>
    /// Obtiene o establece el precio máximo del producto a buscar.
    /// </summary>
    public decimal? MaxPrice { get; set; }
}
