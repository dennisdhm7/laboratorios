using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab03_MVC_Hinojosa.Models
{
    public class ClsBillete
    {
        public decimal monto { get; set; }
        public int b100 { get; set; }
        public int b50 { get; set; }
        public int b20 { get; set; }
        public int b10 { get; set; }

        public int m5 { get; set; }
        public int m2 { get; set; }
        public int m1 { get; set; }
        public int m050 { get; set; }
        public int m020 { get; set; }
        public int m010 { get; set; }
        public int m005 { get; set; }
        public int m002 { get; set; }
        public int m001 { get; set; }

        public int totalBilletes { get; set; }
        public int totalMonedas { get; set; }
    }
}