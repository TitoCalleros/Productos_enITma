using System;
using System.ServiceModel;
using Unity;
using Unity.Wcf;

namespace wcfProductos
{

    public class UnityServiceHostFactory : Unity.Wcf.UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            UnityConfig.GetConfiguredContainer();
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = UnityConfig.GetConfiguredContainer();
            return new UnityServiceHost(container, serviceType, baseAddresses);
        }
    }
}