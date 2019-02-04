
using GAP.Seguros.Core.Contratos;
using GAP.Seguros.Core.Contratos.Manager;
using GAP.Seguros.Core.Dtos;
using GAP.Seguros.Core.Enums;
using System;

namespace GAP.Seguros.Infrastructure.Manager
{
    public class PolizasManager : IPolizasManager
    {
        public PolizasManager()
        {
        }

        public bool ValidarPolizaGuardar(Poliza poliza)
        {
            // Si una poliza contiene una línea de riesgo alto,el porcentaje de cubrimiento debe ser <= 50 %.
            return !(poliza.Riesgo == (int)TipoRiesgo.Alto && poliza.PorcentajeCubrimiento > 50);
        }
    }
}
