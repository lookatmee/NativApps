using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;

namespace NativApps.Products.Data;

public class ProductDBContext : DbContext
{
    public ProductDBContext()
    {
            
    }
    public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }
}
