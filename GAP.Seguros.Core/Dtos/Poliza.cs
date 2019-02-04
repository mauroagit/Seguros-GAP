using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Seguros.Core.Dtos
{
    public class Poliza
    {
        public Guid? Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int PeriodoCobertura { get; set; }

        public float PorcentajeCubrimiento { get; set; }

        public int Riesgo { get; set; }

        public string RiesgoTexto { get; set; }

        public IEnumerable<Cubrimiento> Cubrimientos { get; set; }

        public Guid UsuarioCreacionId { get; set; }

        public Guid UsuarioModificacionId { get; set; }
    }
}
