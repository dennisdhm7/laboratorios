using System.ComponentModel.DataAnnotations;

namespace PracticaCalifica_ChristianHinojosa.Models
{
    public class Docente
    {
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string CorreoCorporativo { get; set; }

        public bool Activo { get; set; }
    }
}
