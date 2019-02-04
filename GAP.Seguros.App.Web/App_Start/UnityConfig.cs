using GAP.Seguros.App.Web.Contratos;
using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Infrastructure.Modelo;
using GAP.Seguros.Infrastructure.Persistencia;
using GAP.Seguros.App.Web.Servicios;
using System;

using Unity;
using Unity.Injection;
using GAP.Seguros.Core.Contratos.Manager;
using GAP.Seguros.Infrastructure.Manager;

namespace GAP.Seguros.App.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // TODO: Register your type's mappings here.
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(new SegurosGAPEntities()));
            container.RegisterType<IServicioPolizas, ServicioPolizas>();
            container.RegisterType<IPolizasManager, PolizasManager>();
        }

        public static void RegisterComponents()
        {
            RegisterTypes(UnityConfig.Container);
        }
    }
}