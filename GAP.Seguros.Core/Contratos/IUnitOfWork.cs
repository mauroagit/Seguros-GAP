using GAP.Seguros.Core.Contratos.Repositorios;
using System;

namespace GAP.Seguros.Core.Contratos
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioPoliza Polizas { get; }

        int Complete();
    }
}
