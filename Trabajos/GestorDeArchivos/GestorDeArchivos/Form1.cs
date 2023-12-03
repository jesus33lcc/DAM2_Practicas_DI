using GestorDeArchivos.Utils;
using GestorDeArchivos.Ventanas;
using Microsoft.VisualBasic;

namespace GestorDeArchivos
{
    public partial class Form1 : Form
    {
        public string FicheroActual { get; set; }
        public Form1()
        {
            InitializeComponent();
            reset();
        }

        private void tsmiBorrar_Click(object sender, EventArgs e)
        {
            File.Delete(FicheroActual);
            reset();
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            VentanaArchivos ventanaArchivos = new VentanaArchivos();
            ventanaArchivos.Size = this.Size;
            ventanaArchivos.ShowDialog(this);
        }

        private void tsmiGuardar_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals(Constantes.NUEVO_ARCHIVO))
            {
                VentanaCreate VCrearArchivo = new VentanaCreate(Constantes.CREAR_ARCHIVO,Constantes.FILES);
                VCrearArchivo.Owner = this;
                VCrearArchivo.StartPosition = FormStartPosition.CenterParent;
                VCrearArchivo.ShowDialog();
            }
            File.WriteAllText(FicheroActual, rtbTextArea.Text);
        }

        private void tsmiInfo_Click(object sender, EventArgs e)
        {
            FormInfo ventanaInfo = new FormInfo();
            ventanaInfo.Size = this.Size;
            ventanaInfo.Show();

        }

        private void tsmiNewFile_Click(object sender, EventArgs e)
        {
            reset();
        }
        
        public void reset()
        {
            rtbTextArea.Clear();
            this.Text = Constantes.NUEVO_ARCHIVO;
            FicheroActual = Path.Combine(Constantes.FILES, this.Text + ".txt");
        }
        public void addFile(string archivo)
        {
            rtbTextArea.Clear();
            this.Text = Path.GetFileName(archivo);
            FicheroActual = archivo;
            rtbTextArea.Text = File.ReadAllText(archivo);
        }
    }
}