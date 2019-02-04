using GAP.Seguros.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GAP.Seguros.App.Web.Models
{
    public class PolizaModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Código requerido")]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción requerida")]
        [MaxLength(1000)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Periodo de Cobertura requerido")]
        [Range(1, 12, ErrorMessage = "El valor debe estar entre 1 y 12")]
        public int? PeriodoCobertura { get; set; }

        [Required(ErrorMessage = "Porcentaje requerido")]
        [Range(1, 100)]
        public float? PorcentajeCubrimiento { get; set; }

        [Required(ErrorMessage = "Risego requerido")]
        public int Riesgo { get; set; }

        public string RiesgoTexto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un cubrimiento")]
        [Display(Name = "Cubrimientos")]
        public List<int> CubrimientosIds { get; set; }

        public string CubrimientosTexto {
            get
            {
                return ((this.CubrimientosPosibles != null && this.CubrimientosPosibles.Any()) ?
                    string.Join(", ", this.CubrimientosPosibles.Where(c => this.CubrimientosIds.Contains(c.Id)).Select(c => c.Nombre)) :
                    "");
            }
        }

        public string ErrorAlGuardar { get; set; }

        public IEnumerable<Cubrimiento> CubrimientosPosibles { get; set; }

        public IEnumerable<NivelRiesgo> Riesgos { get; set; }
    }
}