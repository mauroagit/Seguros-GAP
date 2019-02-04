using GAP.Seguros.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.Seguros.App.Web.Models
{
    public class PolizasViewModel
    {
        public List<PolizaModel> Polizas { get; set; }

        public List<NivelRiesgo> Riesgos { get; set; }
    }
}