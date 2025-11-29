using Lab03_MVC_Hinojosa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03_MVC_Hinojosa.Controllers
{
    public class BilleteController : Controller
    {
        // GET: Billete
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalcularDenominacion(ClsBillete billete)
        {

            int Cantidad = (int)Math.Round(billete.monto * 100);

            int cant100, cant50, cant20, cant10;
            int res100, res50, res20, res10;

            int m5, m2, m1, m050, m020, m010, m005, m002, m001;
            int res5, res2, res1, res050, res020, res010, res005, res002;

            cant100 = Cantidad / 10000;    
            res100 = Cantidad % 10000;

            cant50 = res100 / 5000;
            res50 = res100 % 5000;

            cant20 = res50 / 2000;
            res20 = res50 % 2000;

            cant10 = res20 / 1000;
            res10 = res20 % 1000;


            m5 = res10 / 500;
            res5 = res10 % 500;

            m2 = res5 / 200;
            res2 = res5 % 200;

            m1 = res2 / 100;
            res1 = res2 % 100;

            m050 = res1 / 50;
            res050 = res1 % 50;

            m020 = res050 / 20;
            res020 = res050 % 20;

            m010 = res020 / 10;
            res010 = res020 % 10;

            m005 = res010 / 5;
            res005 = res010 % 5;

            m002 = res005 / 2;
            res002 = res005 % 2;

            m001 = res002;

            billete.b100 = cant100;
            billete.b50 = cant50;
            billete.b20 = cant20;
            billete.b10 = cant10;

            billete.m5 = m5;
            billete.m2 = m2;
            billete.m1 = m1;
            billete.m050 = m050;
            billete.m020 = m020;
            billete.m010 = m010;
            billete.m005 = m005;
            billete.m002 = m002;
            billete.m001 = m001;

            billete.totalBilletes = billete.b100 + billete.b50 + billete.b20 + billete.b10;

            billete.totalMonedas = billete.m5 + billete.m2 + billete.m1 + billete.m050 +
                       billete.m020 + billete.m010 + billete.m005 +
                       billete.m002 + billete.m001;

            return View(billete);
        }
    }
}