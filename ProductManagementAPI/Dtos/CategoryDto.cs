namespace ProductManagementAPI.Dtos;

/// <summary>
/// Clase que representa los datos de transferencia de una categoría.
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Identificador único de la categoría.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nombre de la categoría.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Descripción de la categoría.
    /// </summary>
    public string? Description { get; set; }
}
