using System.Collections.Generic;

namespace GAP.Seguros.Core.Contratos.Repositories
{
    public interface IRepositorio<TDto> where TDto : class
    {
        TDto Obtener(object id);

        IEnumerable<TDto> ObtenerTodos();

        void Agregar(TDto entity);

        void AgregarRango(IEnumerable<TDto> entities);

        void Borrar(TDto entity);

        void BorrarRango(IEnumerable<TDto> entities);
    }
}
