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
        string Ruta { get; set; }
        public VentanaCreate()
        {
            InitializeComponent();
        }
        public VentanaCreate(string titulo, string file)
        {
            InitializeComponent();
            Ruta = file;
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
            string file = "";
            if (this.Text.Equals(Constantes.CREAR_ARCHIVO))
            {
                file = Path.Combine(Ruta, txtBoxNombre.Text + ".txt");
                using (File.Create(file));
            }
            else if (this.Text.Equals(Constantes.CREAR_CARPETA))
            {
                file = Path.Combine(Ruta, txtBoxNombre.Text);
                Directory.CreateDirectory(file);
            }

            if (this.Owner is VentanaArchivos)
            {
                VentanaArchivos ventanaArchivos = (VentanaArchivos)this.Owner;
                ventanaArchivos.AddBoton(file);
                ventanaArchivos.LimpiarPanel();
                ventanaArchivos.RellenarPanel(ventanaArchivos.DirectorioActual);
            }else if (this.Owner is Form1)
            {
                Form1 form1 = (Form1)this.Owner;
                form1.Text = txtBoxNombre.Text;
                form1.FicheroActual = file;
            }
            this.Close();
        }
    }
}
