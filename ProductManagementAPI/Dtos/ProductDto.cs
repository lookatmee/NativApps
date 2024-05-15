namespace ProductManagementAPI.Dtos;

public class ProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? CategoryId { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
}
