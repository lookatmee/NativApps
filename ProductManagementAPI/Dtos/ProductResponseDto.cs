namespace ProductManagementAPI.Dtos;

/// <summary>
/// Clase que representa la respuesta de un producto.
/// </summary>
public class ProductResponseDto
{
    /// <summary>
    /// Identificador único del producto.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nombre del producto.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Descripción del producto.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Precio del producto.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Cantidad disponible del producto.
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// Categoría del producto.
    /// </summary>
    public CategoryDto? Category { get; set; }
}
