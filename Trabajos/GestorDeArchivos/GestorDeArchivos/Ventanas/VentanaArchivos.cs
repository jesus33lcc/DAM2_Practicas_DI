using GestorDeArchivos.Objetos;
using GestorDeArchivos.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeArchivos.Ventanas
{
    public partial class VentanaArchivos : Form
    {
        public string DirectorioActual { get; set; }
        public BotonX BotonClickDel { get; set; }
        public VentanaArchivos()
        {
            DirectorioActual = Constantes.FILES;
            InitializeComponent();
            this.Text = DirectorioActual;
            flowLayoutPanel.Controls.Add(CrearBotonAtras());
            RellenarPanel(DirectorioActual);
        }
        public void AddBoton(string archivo)
        {
            BotonX boton = new BotonX();
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
            boton.DoubleClick += Boton_DoubleClick;
            boton.MouseClick += Boton_MouseClick;
            flowLayoutPanel.Controls.Add(boton);
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
        private ContextMenuStrip MenuBotonDelete()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem eliminar = new ToolStripMenuItem("Eliminar");
            eliminar.Click += Delete_Click;
            menu.Items.Add(eliminar);
            return menu;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            EliminarFilesDir(BotonClickDel.Name);
            LimpiarPanel();
            RellenarPanel(DirectorioActual);
        }
        public void EliminarFilesDir(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            else
            {
                foreach (string archivo in Directory.GetFiles(file))
                {
                    File.Delete(archivo);
                }
                foreach (string archivo in Directory.GetDirectories(file))
                {
                    EliminarFilesDir(archivo);
                }
                Directory.Delete(file);
            }
        }
        public void RellenarPanel(string directorio)
        {
            foreach (string archivo in Directory.GetFileSystemEntries(directorio))
            {
                AddBoton(archivo);
            }
        }
        public void LimpiarPanel()
        {
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(CrearBotonAtras());
        }
        public Button CrearBotonAtras()
        {
            Button botonAtras = new Button();
            botonAtras.Text = "ATRAS";
            botonAtras.Click += BotonAtras_Click;
            return botonAtras;
        }

        private void BotonAtras_Click(object? sender, EventArgs e)
        {
            if (DirectorioActual.Equals(Constantes.FILES) || DirectorioActual.Equals(Constantes.NOMBRE_CARPETA_FILES))
            {
                this.Close();
            }
            else
            {
                this.Text = Path.GetDirectoryName(DirectorioActual);
                DirectorioActual = Path.GetDirectoryName(DirectorioActual);
                LimpiarPanel();
                RellenarPanel(DirectorioActual);
            }
        }
        private void Boton_DoubleClick(object? sender, EventArgs e)
        {
            BotonX botonClick = (BotonX)sender;
            if (File.Exists(botonClick.Name))
            {
                Form1 form1 = (Form1)this.Owner;
                form1.addFile(botonClick.Name);
                //usaria this.Close() pero no se porque no funciona
                this.Dispose();
            }
            else
            {
                LimpiarPanel();
                RellenarPanel(botonClick.Name);
                this.Text = botonClick.Name;
                DirectorioActual = botonClick.Name;
            }
        }
        private void Boton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                BotonClickDel = (BotonX)sender;
                ContextMenuStrip menu = MenuBotonDelete();
                menu.Show((Control)sender, e.Location);
            }
        }
        private void flowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = MenuClickDerecho();
                menu.Show(this, e.Location);
            }
        }
        private void Crear_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            VentanaCreate VentanaCrearX = null;
            if (item.Text.Equals(Constantes.CREAR_ARCHIVO))
            {
                VentanaCrearX = new VentanaCreate(Constantes.CREAR_ARCHIVO, DirectorioActual);
            }
            else if (item.Text.Equals(Constantes.CREAR_CARPETA))
            {
                VentanaCrearX = new VentanaCreate(Constantes.CREAR_CARPETA, DirectorioActual);
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
