using Unity;
using Unity.Lifetime;
using Proyecto_BLL.Interfaces;
using Proyecto_BLL.Servicios;
using Proyecto_DAL.Data;
using Proyecto_DAL.Data.Repositorios;
using Proyecto_ENT.Entidades;
using Proyecto_ENT.Interfaces;
using Proyecto_BLL.Mappings;
using AutoMapper;

namespace wcfProductos
{
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        public static IUnityContainer GetConfiguredContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                _container.AddExtension(new Diagnostic());

                // EntityFramework
                _container.RegisterType<ProductosDbContext>(new HierarchicalLifetimeManager());

                // Repositorio
                _container.RegisterType(typeof(IRepositorio<>), typeof(Repositorio<>));
                _container.RegisterType<IProductoRepositorio, ProductoRepositorio>();

                // AutoMapper
                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ProductoProfile>();
                });

                _container.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

                // Servicios
                _container.RegisterType<IProductosService, ProductoService>();

               _container.RegisterType<IProductoWcf, ProductoWcf>();

            }
            return _container;
        }
    }
}