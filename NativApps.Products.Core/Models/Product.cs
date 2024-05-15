namespace NativApps.Products.Core.Models;

public class Product
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }    
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public Category? Category { get; set; }
}
