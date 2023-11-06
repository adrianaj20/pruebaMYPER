using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica.domain.entities
{
    public class Distrito
    {
        [Key]
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string NombreDistrito { get; set; }
    }
}
