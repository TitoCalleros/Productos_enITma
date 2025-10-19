using AutoMapper;
using Proyecto_BLL.DTOs;
using Proyecto_ENT.Entidades;

namespace Proyecto_BLL.Mappings
{
    public class ProductProfile: Profile
    {

        public ProductProfile()
        {
            CreateMap<Producto, ProductoDTO>();

            CreateMap<CreacionProductoDTO, Producto>();
        }
    }
}
