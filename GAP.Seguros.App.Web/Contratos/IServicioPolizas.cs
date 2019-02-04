using GAP.Seguros.App.Web.Models;
using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GAP.Seguros.App.Web.Contratos
{
    public interface IServicioPolizas
    {
        IEnumerable<PolizaModel> ObtenerPolizas();

        PolizaModel ObtenerPoliza(string id);

        bool GuardarPoliza(PolizaModel model, Guid userId);

        void BorrarPoliza(Guid id, Guid userId);

        IEnumerable<NivelRiesgo> ObtenerNivelesRiesgo();

        IEnumerable<Cubrimiento> ObtenerCubrimientos();

        List<Cliente> ObtenerClientes();

        List<ClientePolizaModel> ObtenerClientesPolizas();

        bool AsignarCancelarPolizaCliente(Guid polizaId, Guid clienteId, bool asignar);

        bool AsignarCancelarPolizasCliente(IEnumerable<ClientePoliza> clientesPolizas, Guid clienteId);
    }
}