using Proyecto_BLL.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace wcfProductos
{
    
    [ServiceContract]
    public interface IProductoWcf
    {

        [OperationContract]
        Task<List<ProductoDTO>> RecuperarCatalogo();

        [OperationContract]
        Task<int> AgregarProducto(CreacionProductoDTO productoDTO);
    }


    
}
