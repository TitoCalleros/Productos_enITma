using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Proyecto_BLL.DTOs;
using Proyecto_BLL.Interfaces;
using Proyecto_ENT.Entidades;
using Proyecto_ENT.Interfaces;

namespace Proyecto_BLL.Servicios
{
    public class ProductoService : IProductosService
    {
        private readonly IRepositorio<Producto> _repo;
        private readonly IMapper _mapper;

        public ProductoService(IRepositorio<Producto> repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        public async Task<int> CrearProductoAsync(CreacionProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);

            var idNuevoProducto = await _repo.AgregarAsync(producto);

            return idNuevoProducto;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosAsync()
        {
            var productos = await _repo.ObtenerTodosAsync();
            return _mapper.Map<List<ProductoDTO>>(productos.ToList());
        }
    }
}
