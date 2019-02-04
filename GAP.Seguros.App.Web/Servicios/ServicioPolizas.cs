using GAP.Seguros.App.Web.Contratos;
using GAP.Seguros.App.Web.Models;
using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Core.Contratos.Manager;
using GAP.Seguros.Core.Dtos;
using GAP.Seguros.Infrastructure.Modelo;
using GAP.Seguros.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace GAP.Seguros.App.Web.Servicios
{
    public class ServicioPolizas : IServicioPolizas
    {
        [Dependency]
        IPolizasManager polizasManager { get; set; }

        private readonly IUnitOfWork unitOfWork;

        public ServicioPolizas(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            polizasManager = UnityConfig.Container.Resolve<IPolizasManager>();
        }

        public IEnumerable<PolizaModel> ObtenerPolizas()
        {
            return unitOfWork.Polizas.ObtenerTodos()
                .Select(p => this.TransformarEnPolizaModel(p));
        }

        public PolizaModel ObtenerPoliza(string id)
        {
            return TransformarEnPolizaModel(unitOfWork.Polizas.Obtener(new Guid(id)));
        }

        public bool GuardarPoliza(PolizaModel model, Guid userId)
        {
            var cubrimientosPosibles = unitOfWork.Polizas.ObtenerCubrimientos();

            Poliza poliza = new Poliza
            {
                Id = model.Id,
                Codigo = model.Codigo,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Cubrimientos = cubrimientosPosibles.Where(c => model.CubrimientosIds.Contains(c.Id)),
                PeriodoCobertura = (int)model.PeriodoCobertura,
                PorcentajeCubrimiento = (float)model.PorcentajeCubrimiento,
                Riesgo = model.Riesgo,
            };

            if (!polizasManager.ValidarPolizaGuardar(poliza))
            {
                model.ErrorAlGuardar = "Si el riesgo es alto, el porcentaje debe ser menor o igual a 50%";
                return false;
            }

            if (model.Id == null)
            {
                poliza.UsuarioCreacionId = userId;
                unitOfWork.Polizas.Agregar(poliza);
            }
            else
            {
                poliza.UsuarioModificacionId = userId;
                unitOfWork.Polizas.Editar(poliza);
            }

            unitOfWork.Complete();

            return true;
        }

        public void BorrarPoliza(Guid id, Guid userId)
        {
            unitOfWork.Polizas.Borrar(id, userId);
            unitOfWork.Complete();
        }

        public IEnumerable<NivelRiesgo> ObtenerNivelesRiesgo()
        {
            return unitOfWork.Polizas.ObtenerNivelesRiesgo();
        }

        public IEnumerable<Cubrimiento> ObtenerCubrimientos()
        {
            return unitOfWork.Polizas.ObtenerCubrimientos();
        }

        public List<Cliente> ObtenerClientes()
        {
            return unitOfWork.Polizas.ObtenerClientes();
        }

        public List<ClientePolizaModel> ObtenerClientesPolizas()
        {
            return unitOfWork.Polizas.ObtenerClientesPolizas().Select(c => new ClientePolizaModel
            {
                Activa = c.Activa,
                ClienteId = c.ClienteId,
                ClienteTexto = c.ClienteTexto,
                Id = c.Id,
                InicioVigencia = c.InicioVigencia,
                PolizaId = c.PolizaId,
                PolizaTexto = c.PolizaTexto,
                Precio = c.Precio,
                ValorAsegurado = c.ValorAsegurado
            }).ToList();
        }

        public bool AsignarCancelarPolizaCliente(Guid polizaId, Guid clienteId, bool asignar)
        {
            unitOfWork.Polizas.AsignarCancelarPolizaCliente(polizaId, clienteId, asignar);
            unitOfWork.Complete();
            return true;
        }

        public bool AsignarCancelarPolizasCliente(IEnumerable<ClientePoliza> clientesPolizas, Guid clienteId)
        {

            return false;
        }

        private PolizaModel TransformarEnPolizaModel(Poliza poliza)
        {
            return new PolizaModel
            {
                Id = poliza.Id,
                Codigo = poliza.Codigo,
                Nombre = poliza.Nombre,
                Descripcion = poliza.Descripcion,
                CubrimientosIds = poliza.Cubrimientos.Select(c => (int)c.Id).ToList(),
                PeriodoCobertura = poliza.PeriodoCobertura,
                PorcentajeCubrimiento = poliza.PorcentajeCubrimiento,
                Riesgo = poliza.Riesgo,
                RiesgoTexto = poliza.RiesgoTexto
            };
        }
    }
}