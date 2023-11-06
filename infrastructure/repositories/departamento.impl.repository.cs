
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.database;

namespace prueba_tecnica.infrastructure.repositories 
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ILogger<DepartamentoRepository> _logger;
        private readonly DataContext _context;

        public DepartamentoRepository(ILogger<DepartamentoRepository> logger, DataContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public Departamento Actualizar(Departamento departamento)
        {
            _context.Entry(departamento).State = EntityState.Modified;
            _context.SaveChanges();

            return departamento;
        }

        public Departamento BuscarPorId(int idDepartamento)
        {
            return  _context.Departamento.Find(idDepartamento) ?? throw new Exception();
        }

        public void Eliminar(int idDepartamento)
        {
            var departamento = _context.Departamento.Find(idDepartamento);
            if(departamento == null) 
            {
                throw new Exception();
            }
            _context.Departamento.Remove(departamento);
        }

        public void Guardar(Departamento departamento)
        {
            _context.Add(departamento);
            _context.SaveChanges();

        }

        public List<Departamento> Listar()
        {
            return _context.Departamento.FromSql($"ListarDepartamentos").ToList();
        }
    }
}