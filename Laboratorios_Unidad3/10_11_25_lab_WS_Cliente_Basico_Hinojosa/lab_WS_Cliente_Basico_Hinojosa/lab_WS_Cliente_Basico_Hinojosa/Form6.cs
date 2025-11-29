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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // validar número
            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Ingrese un número válido.");
                return;
            }

            // llamar al servicio
            ServiceReference1.WS_ServerSoapClient ws = new ServiceReference1.WS_ServerSoapClient();
            string datos = ws.Tabla1(numero); // devuelve texto con saltos de línea

            // limpiar grilla
            dgvTabla.Rows.Clear();

            // dividir por líneas
            string[] lineas = datos.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            foreach (string linea in lineas)
            {
                dgvTabla.Rows.Add(numero, "x", i, "=", linea.Trim());
                i++;
            }

            dgvTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}