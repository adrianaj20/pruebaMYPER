
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.database;

namespace prueba_tecnica.infrastructure.repositories 
{
    public class DistritoRepository : IDistritoRepository
    {
        private readonly ILogger<DistritoRepository> _logger;
        private readonly DataContext _context;

        public DistritoRepository(ILogger<DistritoRepository> logger, DataContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public Distrito Actualizar(Distrito distrito)
        {
            _context.Entry(distrito).State = EntityState.Modified;
            _context.SaveChanges();

            return distrito;
        }

        public Distrito BuscarPorId(int idDistrito)
        {
            return  _context.Distrito.Find(idDistrito) ?? throw new Exception();
        }

        public void Eliminar(int idDistrito)
        {
            var distrito = _context.Distrito.Find(idDistrito);
            if(distrito == null) 
            {
                throw new Exception();
            }
            _context.Distrito.Remove(distrito);
        }

        public void Guardar(Distrito distrito)
        {
            _context.Add(distrito);
            _context.SaveChanges();

        }

        public List<Distrito> Listar()
        {
            return _context.Distrito.FromSql($"ListarDistritos").ToList();
        }
    }
}