using GestorDeArchivos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeArchivos.Ventanas
{
    public partial class VentanaCreate : Form
    {
        public VentanaCreate()
        {
            InitializeComponent();
        }
        public VentanaCreate(string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
        }

        private void txtBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !e.KeyChar.Equals((char)Keys.Back))
            {
                e.Handled = true;
            }
            btnCrear.Enabled = !txtBoxNombre.Text.Equals("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string ruta = "";
            if (this.Text.Equals(Constantes.CREAR_ARCHIVO))
            {
                ruta = Path.Combine(Constantes.FILES, txtBoxNombre.Text + ".txt");
                File.Create(ruta);
            }
            else if (this.Text.Equals(Constantes.CREAR_CARPETA))
            {
                ruta = Path.Combine(Constantes.FILES, txtBoxNombre.Text);
                Directory.CreateDirectory(ruta);
            }

            VentanaArchivos ventanaArchivos = (VentanaArchivos)this.Owner;
            ventanaArchivos.AddBoton(ruta);
            this.Close();
        }
    }
}
