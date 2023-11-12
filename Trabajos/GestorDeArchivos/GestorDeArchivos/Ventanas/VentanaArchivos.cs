using GestorDeArchivos.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections;
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
    public partial class VentanaArchivos : Form
    {
        public VentanaArchivos()
        {
            InitializeComponent();
            if (!Directory.Exists(Constantes.FILES))
            {
                Directory.CreateDirectory(Constantes.FILES);
            }
            foreach (string archivo in Directory.GetFileSystemEntries(Constantes.FILES))
            {
                AddBoton(archivo);
            }
        }
        public void AddBoton(string archivo)
        {
            Button boton = new Button();
            boton.Size = new Size(100, 125);
            boton.AutoSize = false;
            string nombreArchivo = Path.GetFileName(archivo);
            boton.Text = nombreArchivo;
            if (File.Exists(archivo))
            {
                boton.Image = Image.FromFile(Constantes.TXT);
            }
            else
            {
                boton.Image = Image.FromFile(Constantes.CARPETA);
            }
            boton.ImageAlign = ContentAlignment.MiddleCenter;
            boton.TextImageRelation = TextImageRelation.ImageAboveText;
            boton.BackgroundImageLayout = ImageLayout.Zoom;
            boton.TextAlign = ContentAlignment.BottomCenter;
            boton.Name = archivo;
            flowLayoutPanel.Controls.Add(boton);
        }

        private void flowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = MenuClickDerecho();
                menu.Show(this, e.Location);
            }
        }
        private ContextMenuStrip MenuClickDerecho()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem crearArchivo = new ToolStripMenuItem(Constantes.CREAR_ARCHIVO);
            crearArchivo.Click += Crear_Click;
            menu.Items.Add(crearArchivo);
            ToolStripMenuItem crearCarpeta = new ToolStripMenuItem(Constantes.CREAR_CARPETA);
            crearCarpeta.Click += Crear_Click;
            menu.Items.Add(crearCarpeta);
            return menu;
        }
        private void Crear_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            VentanaCreate VentanaCrearX = null;
            if (item.Text.Equals(Constantes.CREAR_ARCHIVO))
            {
                VentanaCrearX = new VentanaCreate(Constantes.CREAR_ARCHIVO);
            }
            else if (item.Text.Equals(Constantes.CREAR_CARPETA))
            {
                VentanaCrearX = new VentanaCreate(Constantes.CREAR_CARPETA);
            }
            else
            {
                VentanaCrearX = new VentanaCreate();
            }
            VentanaCrearX.Owner = this;
            VentanaCrearX.StartPosition = FormStartPosition.CenterParent;
            VentanaCrearX.ShowDialog();
        }
    }
}
