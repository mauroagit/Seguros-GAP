using GAP.Seguros.Core.Contratos.Repositories;
using GAP.Seguros.Core.Contratos.Repositorios;
using GAP.Seguros.Core.Dtos;
using GAP.Seguros.Infrastructure.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GAP.Seguros.Infrastructure.Persistencia.Repositorios
{
    public class RepositorioPoliza : IRepositorioPoliza
    {
        private readonly IRepositorio<Polizas> repositorioPolizas;
        private readonly IRepositorio<NivelesRiesgo> repositorioRiesgo;
        private readonly IRepositorio<Cubrimientos> repositorioCubrimientos;
        private readonly IRepositorio<CubrimientosPoliza> repositorioCubrimientosPoliza;
        private readonly IRepositorio<Clientes> repositorioClientes;
        private readonly IRepositorio<ClientesPolizas> repositorioClientesPolizas;

        public RepositorioPoliza(SegurosGAPEntities contexto)
        {
            repositorioPolizas = new Repositorio<Polizas>(contexto);
            repositorioRiesgo = new Repositorio<NivelesRiesgo>(contexto);
            repositorioCubrimientos = new Repositorio<Cubrimientos>(contexto);
            repositorioCubrimientosPoliza = new Repositorio<CubrimientosPoliza>(contexto);
            repositorioClientes = new Repositorio<Clientes>(contexto);
            repositorioClientesPolizas = new Repositorio<ClientesPolizas>(contexto);
        }

        private Poliza TransformarEnPolizaDto(Polizas poliza)
        {
            return new Poliza
            {
                Id = poliza.Id,
                Codigo = poliza.Codigo,
                Nombre = poliza.Nombre,
                Descripcion = poliza.Descripcion,
                PeriodoCobertura = poliza.PeriodoCobertura,
                PorcentajeCubrimiento = (float)poliza.PorcentajeCubrimiento,
                Riesgo = poliza.Riesgo,
                RiesgoTexto = poliza.NivelesRiesgo.Nombre,
                Cubrimientos = poliza.CubrimientosPoliza.Select(c => new Cubrimiento
                {
                    Id = c.Cubrimientos.Id,
                    Nombre = c.Cubrimientos.Nombre
                })
            };
        }

        public Poliza Obtener(object id)
        {
            return TransformarEnPolizaDto(repositorioPolizas.Obtener(id));
        }

        public new IEnumerable<Poliza> ObtenerTodos()
        {
            var polizas = repositorioPolizas.ObtenerTodos().ToList();
            return polizas
                .Where(p => p.FechaBorrado == null)
                .Select(p => TransformarEnPolizaDto(p));
        }

        public void Agregar(Poliza poliza)
        {
            var nuevaPoliza = new Polizas
            {
                Codigo = poliza.Codigo,
                Nombre = poliza.Nombre,
                Descripcion = poliza.Descripcion,
                // Cubrimientos = poliza.Cubrimientos,
                PeriodoCobertura = (byte)poliza.PeriodoCobertura,
                PorcentajeCubrimiento = (decimal)poliza.PorcentajeCubrimiento,
                Riesgo = (byte)poliza.Riesgo,
                UsuarioCreacion = poliza.UsuarioCreacionId,
                // FechaCreacion = System.DateTime.Now
            };

            repositorioPolizas.Agregar(nuevaPoliza);

            foreach(var c in poliza.Cubrimientos)
            {
                repositorioCubrimientosPoliza.Agregar(new CubrimientosPoliza
                {
                    Cubrimiento = c.Id,
                    Poliza = nuevaPoliza.Id
                });
            }

            // poliza.Cubrimientos.ForEach(c => )
            // repositorioCubrimientosPoliza

            repositorioPolizas.Agregar(nuevaPoliza);
        }

        public void AgregarRango(IEnumerable<Poliza> polizas)
        {
        }

        public void Editar(Poliza poliza)
        {
            var polizaActual = repositorioPolizas.Obtener(poliza.Id);
            polizaActual.Codigo = poliza.Codigo;
            polizaActual.Nombre = poliza.Nombre;
            polizaActual.Descripcion = poliza.Descripcion;
            polizaActual.PeriodoCobertura = (byte)poliza.PeriodoCobertura;
            polizaActual.PorcentajeCubrimiento = (decimal)poliza.PorcentajeCubrimiento;
            polizaActual.Riesgo = (byte)poliza.Riesgo;
            polizaActual.UsuarioCreacion = poliza.UsuarioCreacionId;
            polizaActual.FechaModificacion = System.DateTime.Now;
            polizaActual.UsuarioModificacion = poliza.UsuarioModificacionId;

            var nuevosCubrimientosIds = poliza.Cubrimientos.Select(c => c.Id).ToList();
            var cubrimientosBorrar = polizaActual.CubrimientosPoliza.Where(c => !nuevosCubrimientosIds.Any(n => n == c.Id)).ToList();
            var cubrimientosBorrarIds = cubrimientosBorrar.Select(c => c.Id);
            var cubrimientosCrear = poliza.Cubrimientos.Where(c => !cubrimientosBorrarIds.Contains(c.Id));

            foreach (var c in cubrimientosBorrar)
            {
                repositorioCubrimientosPoliza.Borrar(c);
            }

            foreach (var c in cubrimientosCrear)
            {
                repositorioCubrimientosPoliza.Agregar(new CubrimientosPoliza
                {
                    Cubrimiento = c.Id,
                    Poliza = polizaActual.Id
                });
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            return repositorioClientes.ObtenerTodos().Select(c => new Cliente
            {
                Id = c.Id,
                Correo = c.Correo,
                Direccion = c.Direccion,
                Identificacion = c.Identificacion,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                TipoCliente = c.TipoCliente
            }).ToList();
        }

        public List<ClientePoliza> ObtenerClientesPolizas()
        {
            return repositorioClientesPolizas.ObtenerTodos().Select(c => new ClientePoliza
            {
                Activa = c.Activa,
                ClienteId = c.Cliente,
                ClienteTexto = c.Clientes.Nombre,
                Id = c.Id, 
                InicioVigencia = c.InicioVigencia,
                PolizaId = c.Poliza,
                PolizaTexto = c.Polizas.Nombre,
                Precio = c.Precio,
                ValorAsegurado = c.ValorAsegurado
            }).ToList();
        }

        public bool AsignarCancelarPolizaCliente(Guid polizaId, Guid clienteId, bool asignar)
        {
            var entidades = repositorioClientesPolizas.ObtenerTodos()
                .Where(c => c.Cliente == clienteId && c.Poliza == polizaId);

            if (entidades.Any()) // && poliza.First().Activa != p.Value)
            {
                entidades.First().Activa = asignar;
            }
            else if (asignar)
            {
                repositorioClientesPolizas.Agregar(new ClientesPolizas
                {
                    Activa = true,
                    Cliente = clienteId,
                    InicioVigencia = DateTime.Now,
                    Poliza = polizaId,
                    Precio = 1000000,
                    ValorAsegurado = 10000000
                });
            }

            return true;
        }

        public bool AsignarCancelarPolizasCliente(IEnumerable<ClientePoliza> clientesPolizas, Guid clienteId)
        {
            var clientesIds = clientesPolizas.Select(c => c.ClienteId).ToList();
            var entidades = repositorioClientesPolizas.ObtenerTodos()
                .Where(c => clientesIds.Contains(c.Cliente));

            foreach (var cp in clientesPolizas)
            {
                var poliza = entidades.Where(c => c.Poliza == cp.PolizaId);
                if (poliza.Any()) // && poliza.First().Activa != p.Value)
                {
                    poliza.First().Activa = cp.Activa;
                }
                else if (cp.Activa)
                {
                    repositorioClientesPolizas.Agregar(new ClientesPolizas
                    {
                        Activa = true,
                        Cliente = cp.ClienteId,
                        InicioVigencia = cp.InicioVigencia,
                        Poliza = cp.PolizaId,
                        Precio = cp.Precio,
                        ValorAsegurado = cp.ValorAsegurado
                    });
                }
            }

            return true;
        }

        public void Borrar(Poliza poliza)
        {
        }

        public void Borrar(Guid id, Guid userId)
        {
            var poliza = repositorioPolizas.Obtener(id);
            poliza.FechaBorrado = DateTime.Now;
            poliza.UsuarioBorrado = userId;
        }

        public void BorrarRango(IEnumerable<Poliza> polizas)
        {
        }

        public IEnumerable<NivelRiesgo> ObtenerNivelesRiesgo()
        {
            var nivelesRiesgo = repositorioRiesgo.ObtenerTodos().ToList();
            return nivelesRiesgo.Select(r => new NivelRiesgo
            {
                Id = r.Id,
                Nombre = r.Nombre
            });
        }

        public IEnumerable<Cubrimiento> ObtenerCubrimientos()
        {
            var cubrimientos = repositorioCubrimientos.ObtenerTodos().ToList();
            return cubrimientos.Select(r => new Cubrimiento
            {
                Id = r.Id,
                Nombre = r.Nombre
            });
        }
    }
}
