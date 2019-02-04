using GAP.Seguros.App.Web.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using GAP.Seguros.App.Web.Contratos;
using System.Linq;
using System.Collections.Generic;
using GAP.Seguros.Core.Dtos;

namespace GAP.Seguros.App.Web.Controllers
{
    public class PolizasController : Controller
    {
        private readonly IServicioPolizas servicioPoliza;

        public PolizasController(IServicioPolizas servicioUoW)
        {
            this.servicioPoliza = servicioUoW;
        }

        public ActionResult Index()
        {
            var model = servicioPoliza.ObtenerPolizas();

            return View(model);
        }

        public ActionResult Crear()
        {
            var model = new PolizaModel();
            model.CubrimientosPosibles = servicioPoliza.ObtenerCubrimientos();
            model.Riesgos = servicioPoliza.ObtenerNivelesRiesgo();

            return View("Poliza", model);
        }

        [HttpPost]
        public ActionResult Guardar(PolizaModel poliza)
        {
            var userId = new Guid(this.User.Identity.GetUserId());
            if (!ModelState.IsValid || !servicioPoliza.GuardarPoliza(poliza, userId))
            {
                poliza.CubrimientosPosibles = servicioPoliza.ObtenerCubrimientos();
                poliza.Riesgos = servicioPoliza.ObtenerNivelesRiesgo();
                return View("Poliza", poliza);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(string id)
        {
            var model = servicioPoliza.ObtenerPoliza(id);
            model.CubrimientosPosibles = servicioPoliza.ObtenerCubrimientos();
            model.Riesgos = servicioPoliza.ObtenerNivelesRiesgo();

            return View("Poliza", model);
        }

        public ActionResult Borrar(Guid id)
        {
            var userId = new Guid(this.User.Identity.GetUserId());
            servicioPoliza.BorrarPoliza(id, userId);

            return RedirectToAction("Index");
        }

        public ActionResult ClientesPolizas()
        {
            var model = new ClientesPolizasModel
            {
                Clientes = servicioPoliza.ObtenerClientes(),
                Polizas = servicioPoliza.ObtenerPolizas().ToList(),
                ClientesPolizas = servicioPoliza.ObtenerClientesPolizas()
            };

            return View("ClientesPolizas", model);
        }

        [HttpPost]
        public ActionResult ClientesPolizas(ClientesPolizasModel model)
        {
            servicioPoliza.AsignarCancelarPolizaCliente(model.PolizaId, model.ClienteId, model.Activar);

            return RedirectToAction("ClientesPolizas");
        }
    }
}