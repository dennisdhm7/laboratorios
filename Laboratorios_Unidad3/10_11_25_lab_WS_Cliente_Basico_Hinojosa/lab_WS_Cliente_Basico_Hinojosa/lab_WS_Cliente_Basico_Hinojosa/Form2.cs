using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_WS_Cliente_Basico_Hinojosa
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtN1.Text=string.Empty;
            txtN2.Text=string.Empty;
            txtResultado.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ServiceReference1.WS_ServerSoapClient ws = new
                ServiceReference1.WS_ServerSoapClient();

            double n1, n2, resultado;

            n1=Convert.ToDouble(txtN1.Text); 
            n2= Convert.ToDouble(txtN2.Text);

            resultado =ws.Suma(n1 , n2);
            txtResultado.Text = resultado.ToString();
        }
    }
}
