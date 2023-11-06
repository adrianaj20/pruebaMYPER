using prueba_tecnica.domain.entities;

namespace prueba_tecnica.domain.repositories
{
    public interface IProvinciaRepository
    {
        void Guardar(Provincia provincia);
        Provincia Actualizar(Provincia provincia);
        List<Provincia> Listar();
        void Eliminar(int idProvincia);
        Provincia BuscarPorId(int idProvincia);
    }
}
