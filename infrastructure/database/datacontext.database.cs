using Microsoft.EntityFrameworkCore;
using prueba_tecnica.domain.entities;

namespace prueba_tecnica.infrastructure.database
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Trabajador> Trabajadores {get;  set;}
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
    }

}