
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.database;

namespace prueba_tecnica.infrastructure.repositories 
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly ILogger<TrabajadorRepository> _logger;
        private readonly DataContext _context;

        public TrabajadorRepository(ILogger<TrabajadorRepository> logger, DataContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public Trabajador Actualizar(Trabajador trabajador)
        {
            _context.Entry(trabajador).State = EntityState.Modified;
            _context.SaveChanges();

            return trabajador;
        }

        public Trabajador BuscarPorId(int idTrabajador)
        {
            return  _context.Trabajadores.Find(idTrabajador) ?? throw new Exception();
        }

        public void Eliminar(int idTrabajador)
        {
            var trabajador = _context.Trabajadores.Find(idTrabajador);
            if(trabajador == null) 
            {
                throw new Exception();
            }
            _context.Trabajadores.Remove(trabajador);
        }

        public void Guardar(Trabajador trabajador)
        {
            _context.Add(trabajador);
            _context.SaveChanges();

        }

        public List<Trabajador> Listar()
        {
            return _context.Trabajadores.FromSql($"ListarTrabajadores").ToList();
        }
    }
}