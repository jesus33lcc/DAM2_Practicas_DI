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
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
            CargarImagen(Constantes.RUTAIMAGEN);
        }
        public void CargarImagen(string ruta)
        {
            Image imagen = Image.FromFile(ruta);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.Image = imagen;
        }
    }
}
