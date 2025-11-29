using System.ComponentModel.DataAnnotations;

namespace PracticaCalifica_ChristianHinojosa.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Nombres { get; set; }

        public string Correo { get; set; }

        public bool Activo { get; set; }
    }
}
