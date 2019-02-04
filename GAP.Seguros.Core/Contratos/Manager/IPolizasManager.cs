using GAP.Seguros.Core.Dtos;
using System;

namespace GAP.Seguros.Core.Contratos.Manager
{
    public interface IPolizasManager
    {
        bool ValidarPolizaGuardar(Poliza poliza);
    }
}
