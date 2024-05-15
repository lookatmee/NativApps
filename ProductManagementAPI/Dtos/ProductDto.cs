namespace ProductManagementAPI.Dtos;

/// <summary>
/// Clase que representa los datos de transferencia de un producto.
/// </summary>
public class ProductDto
{
    /// <summary>
    /// Nombre del producto.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Descripción del producto.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Identificador único de la categoría del producto.
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// Precio del producto.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Cantidad disponible del producto.
    /// </summary>
    public int? Quantity { get; set; }
}
