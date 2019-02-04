using GAP.Seguros.Core.Contratos.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GAP.Seguros.Infrastructure.Persistencia.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>
        // where TDto : class
        where TEntity : class
    {
        protected readonly DbContext Contexto;
        private readonly DbSet<TEntity> entidades;

        public Repositorio(DbContext contexto)
        {
            Contexto = contexto;
            entidades = Contexto.Set<TEntity>();
        }

        public TEntity Obtener(object id)
        {
            return entidades.Find(id);
        }

        public IEnumerable<TEntity> ObtenerTodos()
        {
            return entidades.ToList();
        }

        public void Agregar(TEntity entity)
        {
            entidades.Add(entity);
        }

        public void AgregarRango(IEnumerable<TEntity> entities)
        {
            entidades.AddRange(entities);
        }

        public void Borrar(TEntity entity)
        {
            entidades.Remove(entity);
        }

        public void BorrarRango(IEnumerable<TEntity> entities)
        {
            entidades.RemoveRange(entities);
        }
    }
}
