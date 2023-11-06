using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica.domain.entities
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreProvincia { get; set; }
    }
}
