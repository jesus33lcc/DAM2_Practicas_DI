using GestorDeArchivos.Ventanas;

namespace GestorDeArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiBorrar_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            VentanaArchivos ventanaArchivos = new VentanaArchivos();
            ventanaArchivos.Size = this.Size;
            ventanaArchivos.ShowDialog(this);
        }

        private void tsmiGuardar_Click(object sender, EventArgs e)
        {

        }

        private void tsmiInfo_Click(object sender, EventArgs e)
        {
            FormInfo ventanaInfo = new FormInfo();
            ventanaInfo.Size = this.Size;
            ventanaInfo.Show();
            
        }
    }
}