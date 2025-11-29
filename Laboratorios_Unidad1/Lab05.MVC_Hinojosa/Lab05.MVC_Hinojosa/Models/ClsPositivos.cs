using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab05.MVC_Chite.Models
{
    public class ClsPositivos
    {
        public List<int> numerosPositivos {  get; set; }
        public List<int> numerosNegativos { get; set; }
        public ClsPositivos()
        {
            numerosPositivos = new List<int>();
            numerosNegativos = new List<int>();
        }
    }
}