using prueba_tecnica.domain.entities;

namespace prueba_tecnica.domain.repositories
{
    public interface IDepartamentoRepository
    {
        void Guardar(Departamento departamento);
        Departamento Actualizar(Departamento departamento);
        List<Departamento> Listar();
        void Eliminar(int idDepartamento);
        Departamento BuscarPorId(int idDepartamento);
    }
}
