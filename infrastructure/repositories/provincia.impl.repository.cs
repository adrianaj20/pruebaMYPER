
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.database;

namespace prueba_tecnica.infrastructure.repositories 
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly ILogger<ProvinciaRepository> _logger;
        private readonly DataContext _context;

        public ProvinciaRepository(ILogger<ProvinciaRepository> logger, DataContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public Provincia Actualizar(Provincia provincia)
        {
            _context.Entry(provincia).State = EntityState.Modified;
            _context.SaveChanges();

            return provincia;
        }

        public Provincia BuscarPorId(int idProvincia)
        {
            return  _context.Provincia.Find(idProvincia) ?? throw new Exception();
        }

        public void Eliminar(int idProvincia)
        {
            var provincia = _context.Provincia.Find(idProvincia);
            if(provincia == null) 
            {
                throw new Exception();
            }
            _context.Provincia.Remove(provincia);
        }

        public void Guardar(Provincia provincia)
        {
            _context.Add(provincia);
            _context.SaveChanges();

        }

        public List<Provincia> Listar()
        {
            return _context.Provincia.FromSql($"ListarProvincias").ToList();
        }
    }
}