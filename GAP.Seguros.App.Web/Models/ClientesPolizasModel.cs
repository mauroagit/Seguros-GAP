using GAP.Seguros.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAP.Seguros.App.Web.Models
{
    public class ClientesPolizasModel
    {
        [Required(ErrorMessage = "Cliente requerido")]
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        public Guid PolizaId { get; set; }

        [Display(Name = "Asignar/Cancelar")]
        public bool Activar { get; set; }

        public List<PolizaModel> Polizas { get; set; }

        public List<ClientePolizaModel> ClientesPolizas { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}