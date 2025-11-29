using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_Server_Basico_Hinojosa.WebServices
{
    /// <summary>
    /// Descripción breve de WS_Server
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Server : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string Saludos()
        {
            return "Bienvenidos al curso de Web II";
        }

        [WebMethod]
        public double Suma(double num1, double num2)
        {
            return num1 + num2;
        }

        [WebMethod]
        public double Operaciones(string tipo,double num1, double num2)
        {

            if (tipo == "S")
            {
                return num1 + num2;
            }
            else if (tipo=="R")
            {
                return num1 - num2;
            }
            else if (tipo == "M")
            {
                return num1 * num2;
            }
            else
            {
                if (num1 > num2)
                {
                    return num1 / num2;
                }
                return 0;
            }
        }


        [WebMethod]
        public string Tabla1(int numero)
        {
            string m = "";
            for (int i=0; i<=12; i++)
            {
                int oper = numero * i;
                m+= oper +"\r\n";
            }
            return m;
        }

        [WebMethod]
        public string[] Tabla2(int numero)
        {
            string[] tabla = new string[12];
            for (int i = 1; i <= 12; i++)
            {
                tabla[i-1]=numero + " X "+i+" = "+(numero*i).ToString();
            }
            return tabla;
        }

        [WebMethod]
        public string Fechas(string tipo, int f1, int f2)
        {
            List<int> anos = new List<int>();

            //llenamos la lista con los años entre f1 y f2
            for (int i = f1; i <= f2; i++)
            {
                anos.Add(i);
            }

            string resultado = "";

            
            bool EsBisiesto(int año)
            {
                return (año % 4 == 0 && (año % 100 != 0 || año % 400 == 0));
            }

          
            if (tipo == "B") //años bisiestos
            {
                var bisiestos = anos.Where(a => EsBisiesto(a)).ToList();
                if (bisiestos.Count > 0)
                {
                    resultado = string.Join(", ", bisiestos);
                }
                else
                {
                    resultado = "No hay años bisiestos en este rango.";
                }
            }
            else if (tipo == "N") //años no bisiestos
            {
                var noBisiestos = anos.Where(a => !EsBisiesto(a)).ToList();
                if (noBisiestos.Count > 0)
                {
                    resultado = string.Join(", ", noBisiestos);
                }
                else
                {
                    resultado = "No hay años no bisiestos en este rango.";
                }
            }
            else if (tipo == "A") //odos los años
            {
                resultado = string.Join(", ", anos);
            }
            else
            {
                resultado = "Tipo no válido. Usa 'B' para bisiestos, 'N' para no bisiestos o 'A' para todos los años.";
            }

            return resultado;
        }
    }
}
