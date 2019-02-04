using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Seguros.Core.Dtos
{
    public class ClientePoliza
    {
        public Guid? Id { get; set; }

        public bool Activa { get; set; }

        public Guid ClienteId { get; set; }

        public string ClienteTexto { get; set; }

        public Guid PolizaId { get; set; }

        public string PolizaTexto { get; set; }

        public DateTime InicioVigencia { get; set; }

        public decimal Precio { get; set; }

        public decimal ValorAsegurado { get; set; }
    }
}
