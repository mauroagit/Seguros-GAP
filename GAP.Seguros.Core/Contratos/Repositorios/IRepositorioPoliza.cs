using GAP.Seguros.Core.Contratos.Repositories;
using GAP.Seguros.Core.Dtos;
using System;
using System.Collections.Generic;

namespace GAP.Seguros.Core.Contratos.Repositorios
{
    public interface IRepositorioPoliza : IRepositorio<Poliza>
    {
        IEnumerable<NivelRiesgo> ObtenerNivelesRiesgo();

        IEnumerable<Cubrimiento> ObtenerCubrimientos();

        void Editar(Poliza poliza);

        void Borrar(Guid id, Guid userId);

        List<Cliente> ObtenerClientes();

        List<ClientePoliza> ObtenerClientesPolizas();

        bool AsignarCancelarPolizaCliente(Guid PolizaId, Guid clienteId, bool asignar);

        bool AsignarCancelarPolizasCliente(IEnumerable<ClientePoliza> clientesPolizas, Guid clienteId);
    }
}
