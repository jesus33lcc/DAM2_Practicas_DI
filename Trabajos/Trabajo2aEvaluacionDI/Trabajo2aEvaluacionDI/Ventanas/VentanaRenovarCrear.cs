using System;
using System.Linq;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Conexion;
using Trabajo2aEvaluacionDI.Modelos;
using Trabajo2aEvaluacionDI.Vistas;
using TextBox = System.Windows.Forms.TextBox;

namespace Trabajo2aEvaluacionDI.Ventanas
{
    /// <summary>
    /// Representa una ventana que permite renovar o crear un jugador de fútbol.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class VentanaRenovarCrear : Form
    {
        /// <summary>
        /// Referencia al formulario principal que instanció esta ventana.
        /// </summary>
        UCBaseDeDatos VentanaPadre;
        /// <summary>
        /// Jugador seleccionado para renovación.
        /// </summary>
        Jugador JugadorSeleccionado;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VentanaRenovarCrear"/>
        /// </summary>
        /// <param name="ventanaPadre">Referencia al formulario principal.</param>
        public VentanaRenovarCrear(UCBaseDeDatos ventanaPadre)
        {
            InitializeComponent();
            VentanaPadre = ventanaPadre;
            this.Text = "Nuevo Jugador";
            lblCabecera.Text = "Datos del nuevo jugador";
            btnAceptar.Click += btnConfirmarCrear_Click;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VentanaRenovarCrear"/>
        /// </summary>
        /// <param name="ventanaPadre">Referencia al formulario principal.</param>
        /// <param name="jugador">Jugador seleccionado para renovación.</param>
        public VentanaRenovarCrear(UCBaseDeDatos ventanaPadre, Jugador jugador)
        {
            InitializeComponent();
            VentanaPadre = ventanaPadre;
            JugadorSeleccionado = jugador;
            this.Text = "Renovar Jugador";
            txtBoxNombre.Text = JugadorSeleccionado.Nombre;
            txtBoxPais.Text = JugadorSeleccionado.Pais;
            txtBoxClub.Text = JugadorSeleccionado.Club;
            txtBoxValor.Text = JugadorSeleccionado.Valor.ToString();
            btnAceptar.Click += btnConfirmarRenovar_Click;
        }

        /// <summary>
        /// Maneja el evento Click del botón "Cancelar", cerrando la ventana sin realizar cambios.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// Maneja el evento Click del botón "Aceptar" en el escenario de renovación de jugador, aplicando los cambios.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnConfirmarRenovar_Click(object sender, EventArgs e)
        {
            // Actualiza los datos del jugador seleccionado con la información ingresada.
            JugadorSeleccionado.Nombre = txtBoxNombre.Text;
            JugadorSeleccionado.Pais = txtBoxPais.Text;
            JugadorSeleccionado.Club = txtBoxClub.Text;
            JugadorSeleccionado.Valor = Decimal.Parse(txtBoxValor.Text);
            // Actualiza el jugador en la base de datos de futbolistas.
            ClienteFutbolistas.Instance.Update(JugadorSeleccionado);
            // Actualiza la lista de jugadores en el formulario principal.
            VentanaPadre.btnBuscar.PerformClick();
            // Cierra la ventana de renovación.
            this.Dispose();
        }
        /// <summary>
        /// Maneja el evento Click del botón "Confirmar" en el escenario de creación de nuevo jugador, aplicando los cambios.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnConfirmarCrear_Click(object sender, EventArgs e)
        {
            // Crea un nuevo jugador con la información ingresada.
            Jugador nuevoJugador = new Jugador
            {
                Nombre = txtBoxNombre.Text,
                Pais = txtBoxPais.Text,
                Club = txtBoxClub.Text,
                Valor = Decimal.Parse(txtBoxValor.Text),
                IdTransfermarkt = 0
            };
            // Verifica si el jugador ya existe en la base de datos.
            if (ClienteFutbolistas.Instance.Exist(nuevoJugador))
            {
                MessageBox.Show("Este jugador ya existe");
            }
            // Verifica si hay saldo suficiente para la creación del nuevo jugador.
            else if ((ClienteTransacciones.Instance.GetSaldoActual() - nuevoJugador.Valor) < 0)
            {
                MessageBox.Show("Tu saldo es insuficiente");
            }
            else
            {
                // Crea una transacción de gasto por el valor del nuevo jugador.
                Transaccion transaccion = new Transaccion
                {
                    JugadorNombre = nuevoJugador.Nombre,
                    Ingresos = 0,
                    Gastos = nuevoJugador.Valor,
                    Saldo_Actual = ClienteTransacciones.Instance.GetSaldoActual() - nuevoJugador.Valor
                };
                // Inserta la transacción en la base de datos de transacciones.
                ClienteTransacciones.Instance.Insert(transaccion);
                // Inserta el nuevo jugador en la base de datos de futbolistas.
                ClienteFutbolistas.Instance.Insert(nuevoJugador);
                // Actualiza la lista de jugadores en el formulario principal.
                VentanaPadre.btnBuscar.PerformClick();
                // Cierra la ventana de creación.
                this.Dispose();
            }
        }

        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto de valor, permitiendo solo dígitos y una coma para representar decimales.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="KeyPressEventArgs"/> que contiene los datos del evento.</param>
        private void txtBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar.Equals((char)Keys.Back))
            {
                if ((e.KeyChar == ',') && (txtBoxValor.Text.Equals("") || txtBoxValor.Text.Contains(",")))
                {
                    e.Handled = true;
                }
                else if (char.IsDigit(e.KeyChar))
                {
                    if (e.KeyChar == '0' && txtBoxValor.Text.Equals(""))
                    {
                        e.Handled = true;
                    }
                    else if (txtBoxValor.Text.Contains(","))
                    {
                        string[] separado = txtBoxValor.Text.Split(',');
                        if (separado[1].Length == 2)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (txtBoxValor.Text.Length >= 15)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto, limitando la longitud y permitiendo solo letras (excepto para el cuadro de texto del club, que permite números).
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="KeyPressEventArgs"/> que contiene los datos del evento.</param>
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 50 && !e.KeyChar.Equals((char)Keys.Back))
            {
                e.Handled = true;
            }
            else if ((textBox != txtBoxClub) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Maneja el evento TextChanged de los cuadros de texto, habilitando el botón "Aceptar" según la validez de los datos ingresados.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (ComprobarTextos(txtBoxNombre) && ComprobarTextos(txtBoxPais) && ComprobarTextos(txtBoxClub) && ComprobarValor(txtBoxValor))
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }
        /// <summary>
        /// Verifica la validez de los datos ingresados en un cuadro de texto que representa texto (nombre, país, club).
        /// </summary>
        /// <param name="textBox">Cuadro de texto a verificar.</param>
        /// <returns>true si los datos son válidos, false si no lo son.</returns>
        private bool ComprobarTextos(TextBox textBox)
        {
            bool longitudValida = textBox.Text.Length >= 1 && textBox.Text.Length <= 50;
            bool tieneDigitos = !textBox.Text.Any(char.IsDigit);
            if (textBox == txtBoxClub)
            {
                return longitudValida;
            }
            return (longitudValida && tieneDigitos);
        }
        /// <summary>
        /// Verifica la validez del valor ingresado en el cuadro de texto de valor.
        /// </summary>
        /// <param name="textBox">Cuadro de texto de valor a verificar.</param>
        /// <returns>true si el valor es válido, false si no lo es.</returns>
        private bool ComprobarValor(TextBox textBox)
        {
            if (decimal.TryParse(textBox.Text, out decimal valor))
            {
                if (valor >= 0 && valor <= 999999999999999.99m)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
