using Proyecto_BLL.DTOs;
using Proyecto_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Unity;

namespace wcfProductos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ProductoWcf : IProductoWcf
    {
        private readonly IProductosService _productosService;

        [InjectionConstructor]
        public ProductoWcf(IProductosService productosService)
        {
            _productosService = productosService;
        }

        public async Task<int> AgregarProducto(CreacionProductoDTO productoDTO)
        {
            try
            {
                return await _productosService.CrearProductoAsync(productoDTO);
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error al agregar producto: {ex.Message}");
            }
        }

        public async Task<List<ProductoDTO>> RecuperarCatalogo()
        {
            return await _productosService.ObtenerProductosAsync();
        }
    }
}
