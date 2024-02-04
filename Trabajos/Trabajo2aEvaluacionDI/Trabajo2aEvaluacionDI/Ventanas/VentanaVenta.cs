using System;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Conexion;
using Trabajo2aEvaluacionDI.Modelos;
using Trabajo2aEvaluacionDI.Vistas;

namespace Trabajo2aEvaluacionDI.Ventanas
{
    /// <summary>
    /// Representa una ventana para realizar la venta de un jugador de fútbol.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class VentanaVenta : Form
    {
        /// <summary>
        /// Referencia al formulario principal que instanció esta ventana.
        /// </summary>
        UCBaseDeDatos VentanaPadre;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VentanaVenta"/>
        /// </summary>
        /// <param name="uCBaseDeDatos">Instancia del formulario principal que invoca esta ventana.</param>
        public VentanaVenta(UCBaseDeDatos uCBaseDeDatos)
        {
            InitializeComponent();
            VentanaPadre = uCBaseDeDatos;
            // Calcula y muestra el valor total a confirmar (saldo actual + valor del jugador a vender
            lblValorCalculado.Text = (ClienteTransacciones.Instance.GetSaldoActual() + VentanaPadre.JugadorSeleccionado.Valor).ToString();
        }

        /// <summary>
        /// Maneja el evento Click del botón "Confirmar", realizando la transacción de venta.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Crea una nueva transacción de venta.
            Transaccion transaccion = new Transaccion
            {
                JugadorNombre = VentanaPadre.JugadorSeleccionado.Nombre,
                Ingresos = VentanaPadre.JugadorSeleccionado.Valor,
                Gastos = 0,
                Saldo_Actual = ClienteTransacciones.Instance.GetSaldoActual() + VentanaPadre.JugadorSeleccionado.Valor
            };
            // Inserta la transacción en la base de datos de transacciones.
            ClienteTransacciones.Instance.Insert(transaccion);
            // Elimina el jugador vendido de la base de datos de futbolistas.
            ClienteFutbolistas.Instance.Delete(VentanaPadre.JugadorSeleccionado);
            // Actualiza la lista de jugadores en el formulario principal.
            VentanaPadre.btnBuscar.PerformClick();
            // Cierra la ventana de venta.
            this.Dispose();
        }

        /// <summary>
        /// Maneja el evento Click del botón "Cancelar", cerrando la ventana sin realizar la venta.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cierra la ventana de venta sin realizar ninguna acción.
            this.Dispose();
        }
    }
}
