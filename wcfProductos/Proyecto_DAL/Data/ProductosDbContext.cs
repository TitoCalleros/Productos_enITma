using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_ENT.Entidades;

namespace Proyecto_DAL.Data
{
    public class ProductosDbContext : DbContext
    {

        public ProductosDbContext()
        {            
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
