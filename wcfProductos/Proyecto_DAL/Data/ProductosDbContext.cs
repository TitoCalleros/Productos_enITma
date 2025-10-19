using Proyecto_ENT.Entidades;
using System.Data.Entity;

namespace Proyecto_DAL.Data
{
    public class ProductosDbContext : DbContext
    {

        public ProductosDbContext() : base("ProductosConnection")
        {
            // Deshabilitar la inicialización automática de la base de datos
            Database.SetInitializer<ProductosDbContext>(null);
        }

        public DbSet<Exa_CatalogoProducto> Productos { get; set; }
    }
}
