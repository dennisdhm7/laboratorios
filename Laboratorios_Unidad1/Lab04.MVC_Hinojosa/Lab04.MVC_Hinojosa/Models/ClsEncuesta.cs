using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab04.MVC_Chite.Models
{
    public class ClsEncuesta
    {
        [Required(ErrorMessage = "Debe seleccionar una opción")]
        public string OpcionSeleccionada { get; set; }
        public List<string> Opciones { get; set; }

        public Dictionary<string, int> Votos { get; set; }

        public ClsEncuesta() 
        {
            Opciones = new List<string> { "Java", "C#", "Python", "C++", "PHP", "Cobal"};
            Votos = new Dictionary<string, int>();
            foreach (var opcion in Opciones)
                Votos[opcion] = 0;
        }

    }
}