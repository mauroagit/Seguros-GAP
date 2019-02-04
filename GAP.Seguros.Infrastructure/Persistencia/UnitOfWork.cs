using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Core.Contratos.Repositorios;
using GAP.Seguros.Infrastructure.Modelo;
using GAP.Seguros.Infrastructure.Persistencia.Repositorios;

namespace GAP.Seguros.Infrastructure.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SegurosGAPEntities context;

        public UnitOfWork(SegurosGAPEntities context)
        {
            this.context = context;
            Polizas = new RepositorioPoliza(context);
        }

        public IRepositorioPoliza Polizas { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
