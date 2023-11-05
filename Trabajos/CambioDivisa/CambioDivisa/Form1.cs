using CambioDivisa.UTILS;

namespace CambioDivisa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbBoxDe.Text = "Euros";
            cmbBoxA.Text = "Dollars";
            FilesUtils.CargarHistorico(lstBoxHistorico);

        }

        private void txtBImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar.Equals((char)Keys.Back))
            {
                if ((e.KeyChar == ',') && (txtBImporte.Text.Equals("") || txtBImporte.Text.Contains(",")))
                {
                    e.Handled = true;
                }
                else if (char.IsDigit(e.KeyChar) && txtBImporte.Text.Contains(","))
                {
                    string[] separado = txtBImporte.Text.Split(",");
                    if (separado[1].Length == 2)
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '0' && txtBImporte.Text.Equals(""))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
            //Para habilitar el boton si esta vacio
            if (!txtBImporte.Text.Equals(""))
            {
                btnCambiar.Enabled = true;
            }
            else
            {
                btnCambiar.Enabled = false;
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            decimal devolucion = CambiaDivisas.CambioDivisa(decimal.Parse(txtBImporte.Text), cmbBoxDe.Text, cmbBoxA.Text);
            devolucion = Math.Round(devolucion, 2);
            string registro = $"{DateTime.Now} Importe {txtBImporte.Text} {cmbBoxDe.Text.ToLower()} - {devolucion} {cmbBoxA.Text.ToLower()}";
            lstBoxHistorico.Items.Add(registro);
            FilesUtils.GuardarRegistro(registro);
        }

        private void btnDobleFlecha_Click(object sender, EventArgs e)
        {
            string txtOrigen = cmbBoxDe.Text;
            cmbBoxDe.Text = cmbBoxA.Text;
            cmbBoxA.Text = txtOrigen;
        }
    }
}