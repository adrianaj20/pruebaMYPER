using prueba_tecnica.domain.entities;

namespace prueba_tecnica.domain.repositories 
{
    public interface ITrabajadorRepository 
    {
        void Guardar(Trabajador trabajador);
        Trabajador Actualizar(Trabajador trabajador);
        List<Trabajador> Listar();
        void Eliminar(int idTrabajador);
        Trabajador BuscarPorId(int idTrabajador);
    }
}
