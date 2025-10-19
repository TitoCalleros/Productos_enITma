using AutoMapper;
using Proyecto_BLL.DTOs;
using Proyecto_ENT.Entidades;

namespace Proyecto_BLL.Mappings
{
    public class ProductoProfile: Profile
    {

        public ProductoProfile()
        {
            CreateMap<Exa_CatalogoProducto, ProductoDTO>();

            CreateMap<CreacionProductoDTO, Exa_CatalogoProducto>();
        }
    }
}
