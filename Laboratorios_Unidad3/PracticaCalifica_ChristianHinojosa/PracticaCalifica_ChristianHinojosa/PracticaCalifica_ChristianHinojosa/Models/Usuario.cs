using System.ComponentModel.DataAnnotations;

namespace PracticaCalifica_ChristianHinojosa.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Password { get; set; }

        public string Rol { get; set; }
    }
}
