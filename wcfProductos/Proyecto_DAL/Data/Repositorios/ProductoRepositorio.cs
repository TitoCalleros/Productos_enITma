using Proyecto_ENT.Entidades;
using Proyecto_ENT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DAL.Data.Repositorios
{
    public interface IProductoRepositorio : IRepositorio<Exa_CatalogoProducto>
    {        
    }

    public class ProductoRepositorio: Repositorio<Exa_CatalogoProducto>, IProductoRepositorio
    {

        public ProductoRepositorio(ProductosDbContext context) : base(context) { }

        public new async Task<IEnumerable<Exa_CatalogoProducto>> ObtenerTodosAsync() 
        {
            return await _context.Database.SqlQuery<Exa_CatalogoProducto>("EXEC Ventas.sp_GetAllCatalogoProd").ToListAsync();
        }

        public new async Task<int> AgregarAsync(Exa_CatalogoProducto entidad)
        {
            try
            {
                var idProducto = await _context.Database.SqlQuery<int>("EXEC Ventas.sp_InsertarCatalogoProducto @Descripcion, @IdUsuario",
                    new SqlParameter("@Descripcion", entidad.Descripcion),
                    new SqlParameter("@IdUsuario", entidad.IdUsuario)
                ).FirstAsync();

                return idProducto;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al insertar producto: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al insertar producto: {ex.Message}", ex);
            }           
        }
    }
}
