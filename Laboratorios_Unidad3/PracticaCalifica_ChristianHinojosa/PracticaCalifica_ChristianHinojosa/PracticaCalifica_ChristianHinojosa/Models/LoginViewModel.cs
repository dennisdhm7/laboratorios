using System.ComponentModel.DataAnnotations;

namespace PracticaCalifica_ChristianHinojosa.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese su correo.")]
        [EmailAddress(ErrorMessage = "Correo no válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña.")]
        public string Password { get; set; }
    }
}
