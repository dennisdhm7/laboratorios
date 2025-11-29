using lab_WS_Cliente_Basico_Hinojosa.ServiceReference1;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            CargarCombo();
        }

        void CargarCombo()
        {
            cboOperaciones.Items.Clear();
            cboOperaciones.Items.Add(new KeyValuePair<string, string>("S", "Suma"));
            cboOperaciones.Items.Add(new KeyValuePair<string, string>("R", "Resta"));
            cboOperaciones.Items.Add(new KeyValuePair<string, string>("M", "Multiplicación"));
            cboOperaciones.Items.Add(new KeyValuePair<string, string>("D", "División"));
            cboOperaciones.DisplayMember = "Value";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ServiceReference1.WS_ServerSoapClient ws = new
                ServiceReference1.WS_ServerSoapClient();

            double n1, n2, resultado;

            n1 = Convert.ToDouble(txtN1.Text);
            n2 = Convert.ToDouble(txtN2.Text);

            resultado = ws.Operaciones(((KeyValuePair<string, string>)cboOperaciones.SelectedItem).Key, n1, n2);

            txtResultado.Text = resultado.ToString();
        }
    }
}
