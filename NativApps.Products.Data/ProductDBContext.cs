using Microsoft.EntityFrameworkCore;
using NativApps.Products.Core.Models;

namespace NativApps.Products.Data
{
    /// <summary>
    /// Contexto de la base de datos para la aplicación de gestión de productos.
    /// </summary>
    public class ProductDBContext : DbContext
    {
        /// <summary>
        /// Constructor por defecto del contexto de la base de datos.
        /// </summary>
        public ProductDBContext()
        {

        }

        /// <summary>
        /// Constructor del contexto de la base de datos que toma opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto de la base de datos.</param>
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

        /// <summary>
        /// Conjunto de entidades de la tabla de categorías en la base de datos.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; } = null!;

        /// <summary>
        /// Conjunto de entidades de la tabla de productos en la base de datos.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; } = null!;

        /// <summary>
        /// Conjunto de entidades de la tabla de roles en la base de datos.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; } = null!;

        /// <summary>
        /// Conjunto de entidades de la tabla de usuarios en la base de datos.
        /// </summary>
        public virtual DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Método llamado cuando la configuración de opciones del contexto de la base de datos no ha sido especificada.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones para el contexto de la base de datos.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aquí puedes especificar la cadena de conexión si no está configurada
            }
        }
    }
}
