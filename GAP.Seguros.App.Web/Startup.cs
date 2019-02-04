using Microsoft.Owin;
using Owin;
using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Infrastructure.Persistencia;
using GAP.Seguros.Infrastructure.Modelo;

[assembly: OwinStartupAttribute(typeof(GAP.Seguros.App.Web.Startup))]
namespace GAP.Seguros.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
