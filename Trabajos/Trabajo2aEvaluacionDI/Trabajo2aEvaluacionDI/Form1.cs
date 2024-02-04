using System;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Vistas;

namespace Trabajo2aEvaluacionDI
{
    /// <summary>
    /// Clase principal que representa la ventana principal de la aplicación.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Main : Form
    {
        /// <summary>
        /// Panel para la vista de la base de datos.
        /// </summary>
        UCBaseDeDatos panelBaseDeDatos;
        /// <summary>
        /// Panel para la vista de análisis.
        /// </summary>
        UCAnalisis panelAnalisis;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Main"/>.
        /// </summary>
        public Main()
        {
            // Se inicializan los paneles y se configura su diseño de llenado.
            panelBaseDeDatos = new UCBaseDeDatos();
            panelBaseDeDatos.Dock = DockStyle.Fill;
            panelAnalisis = new UCAnalisis();
            panelAnalisis.Dock = DockStyle.Fill;
            // Inicializa los componentes visuales.
            InitializeComponent();
            // Agrega el panel de la base de datos al control principal.
            panelMain.Controls.Add(panelBaseDeDatos);
        }

        /// <summary>
        /// Maneja el evento Click del control tsmBaseDatos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void tsmBaseDatos_Click(object sender, EventArgs e)
        {
            // Cambia al panel de la base de datos si no está actualmente seleccionado.
            if (panelMain.Controls[0] != panelBaseDeDatos)
            {
                panelMain.Controls.Clear();
                panelMain.Controls.Add(panelBaseDeDatos);
            }
        }

        /// <summary>
        /// Maneja el evento Click del control tsmAnalisis.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void tsmAnalisis_Click(object sender, EventArgs e)
        {
            // Cambia al panel de análisis si no está actualmente seleccionado.
            if (panelMain.Controls[0] != panelAnalisis)
            {
                panelMain.Controls.Clear();
                panelMain.Controls.Add(panelAnalisis);
            }
        }
    }
}
