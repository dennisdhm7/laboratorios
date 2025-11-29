using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01.MVC_Hinojosa.Models
{
    public class ClsPersona
    {
        public string apellido {  get; set; }
        public string nombres { get; set; }
        public string email { get; set; }
        public int edad { get; set; }
        public double peso { get; set; }
        public bool sexo { get; set; }
    }
}