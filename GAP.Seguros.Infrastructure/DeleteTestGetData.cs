using GAP.Seguros.Core.Dtos;
using GAP.Seguros.Infrastructure.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Seguros.Infrastructure
{
    public static class DeleteTestGetData
    {
        public static NivelRiesgo[] NivelesRiesgo()
        {
            using (SegurosGAPEntities context = new SegurosGAPEntities())
            {
                var nivelesRiesgo = context.NivelesRiesgo.Select(r => new NivelRiesgo
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                }).ToArray();

                return nivelesRiesgo;
            }
        }

        public static Cubrimiento[] Cubrimientos()
        {
            using (SegurosGAPEntities context = new SegurosGAPEntities())
            {
                var cubrimientos = context.Cubrimientos.Select(r => new Cubrimiento
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                }).ToArray();

                return cubrimientos;
            }
        }
    }
}
