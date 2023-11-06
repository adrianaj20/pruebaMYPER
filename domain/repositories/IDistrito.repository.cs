using prueba_tecnica.domain.entities;

namespace prueba_tecnica.domain.repositories
{
    public interface IDistritoRepository
    {
        void Guardar(Distrito distrito);
        Distrito Actualizar(Distrito distrito);
        List<Distrito> Listar();
        void Eliminar(int idDistrito);
        Distrito BuscarPorId(int idDistrito);
    }
}
