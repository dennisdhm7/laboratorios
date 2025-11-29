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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            ServiceReference1.WS_ServerSoapClient ws = new ServiceReference1.WS_ServerSoapClient();

            int numero;
            numero = int.Parse(txtNumero.Text);

            dgvTabla.Rows.Clear();
            var resultado=ws.Tabla2(numero);

            foreach (var item in resultado) 
            {
                dgvTabla.Rows.Add(item);
            }
        }
    }
}
