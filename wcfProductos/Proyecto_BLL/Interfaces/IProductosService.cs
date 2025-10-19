using Proyecto_BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_BLL.Interfaces
{
    public interface IProductosService
    {
        Task<List<ProductoDTO>> ObtenerProductosAsync();
        Task<int> CrearProductoAsync(CreacionProductoDTO productoDTO);
    }
}
