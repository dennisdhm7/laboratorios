using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02.MVC_Chite.Models
{
    public class ClsPersona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int edad {  get; set; }
        public double estatura { get; set; }
        public bool soltero { get; set; }
    }
}