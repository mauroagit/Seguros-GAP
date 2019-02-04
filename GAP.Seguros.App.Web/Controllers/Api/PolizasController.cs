using GAP.Seguros.App.Web.Contratos;
using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace GAP.Seguros.App.Web.Controllers.Api
{
    public class PolizasController : ApiController
    {
        private readonly IServicioPolizas servicioUoW;

        public PolizasController(IServicioPolizas servicioUoW)
        {
            this.servicioUoW = servicioUoW;
        }

        [HttpPost]
        public IHttpActionResult Borrar(Guid id)
        {
            var userId = new Guid(this.User.Identity.GetUserId());
            servicioUoW.BorrarPoliza(id, userId);

            return Ok();
        }
    }
}
