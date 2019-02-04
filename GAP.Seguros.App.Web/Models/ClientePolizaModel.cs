using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.Seguros.App.Web.Models
{
    public class ClientePolizaModel
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