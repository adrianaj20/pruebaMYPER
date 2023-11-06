using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica.domain.entities
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string NombreDepartamento { get; set; }
    }
}
