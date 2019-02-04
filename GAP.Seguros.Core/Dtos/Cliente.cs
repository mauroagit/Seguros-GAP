using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Seguros.Core.Dtos
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public int TipoCliente { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Correo { get; set; }
    }
}
