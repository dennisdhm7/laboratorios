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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Por favor, ingrese un número válido.");
                return;
            }

            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Ingrese solo números enteros.");
                return;
            }

            ServiceReference1.WS_ServerSoapClient ws = new ServiceReference1.WS_ServerSoapClient();
            var resultado = ws.Tabla2(numero); 


            dgvTabla.Rows.Clear();


            foreach (var item in resultado)
            {
 
                string[] partes = item.Split(' ');

                if (partes.Length >= 5)
                {
                    dgvTabla.Rows.Add(partes[0], partes[1], partes[2], partes[3], partes[4]);
                }
            }

            // Ajustes visuales
            dgvTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
