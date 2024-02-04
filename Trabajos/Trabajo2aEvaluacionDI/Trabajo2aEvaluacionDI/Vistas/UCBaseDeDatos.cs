using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Conexion;
using Trabajo2aEvaluacionDI.Elementos;
using Trabajo2aEvaluacionDI.Modelos;
using Trabajo2aEvaluacionDI.Utils;
using Trabajo2aEvaluacionDI.Ventanas;

namespace Trabajo2aEvaluacionDI.Vistas
{
    /// <summary>
    /// Control de usuario que representa la interfaz de una base de datos de jugadores de fútbol.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCBaseDeDatos : UserControl
    {
        /// <summary>
        /// Lista de jugadores utilizada para el enlace de datos.
        /// </summary>
        BindingList<Jugador> listaJugadores;
        /// <summary>
        /// Control de usuario para mostrar los datos de un jugador seleccionado.
        /// </summary>
        UCPerfil DatosJugador;
        /// <summary>
        /// Obtiene o establece el jugador seleccionado en la interfaz.
        /// </summary>
        /// <value>
        /// El jugador seleccionado.
        /// </value>
        public Jugador JugadorSeleccionado { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCBaseDeDatos"/>
        /// </summary>
        public UCBaseDeDatos()
        {
            InitializeComponent();
            DatosJugador = new UCPerfil();
            panelDatos.Controls.Add(DatosJugador);
            GenerarBidingList();
        }

        /// <summary>
        /// Maneja el evento Click del botón de búsqueda, actualizando la lista de jugadores.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listaJugadores.Clear();
            SortedSet<Jugador> jugadoresObtenidos = new SortedSet<Jugador>();
            foreach (Jugador jugador in BuscarJugador())
            {
                listaJugadores.Add(jugador);
            }
            JugadorSeleccionado = null;
            DatosJugador.LimpiarDatos();
        }
        /// <summary>
        /// Realiza la búsqueda de jugadores según los criterios de búsqueda proporcionados.
        /// </summary>
        /// <returns>Una lista de jugadores que coinciden con los criterios de búsqueda.</returns>
        private List<Jugador> BuscarJugador()
        {
            // Crea listas de jugadores basadas en diferentes criterios de búsqueda.
            List<Jugador> jugadoresBuscados = new List<Jugador>();
            List<List<Jugador>> listaListas = new List<List<Jugador>>();

            if (txtBoxNombre.Text.Length != 0)
            {
                listaListas.Add(ClienteFutbolistas.Instance.BuscarPor(txtBoxNombre.Text, Constantes.NOMBRE_CAMPO_NOMBRE));
            }
            if (txtboxClub.Text.Length != 0)
            {
                listaListas.Add(ClienteFutbolistas.Instance.BuscarPor(txtboxClub.Text, Constantes.NOMBRE_CAMPO_CLUB));
            }
            if (txtBoxPais.Text.Length != 0)
            {
                listaListas.Add(ClienteFutbolistas.Instance.BuscarPor(txtBoxPais.Text, Constantes.NOMBRE_CAMPO_PAIS));
            }
            if (txtBoxValor.Text.Length != 0)
            {
                if (decimal.TryParse(txtBoxValor.Text, out decimal valor))
                {
                    if (valor >= 0 && valor <= 999999999999999.99m)
                    {
                        listaListas.Add(ClienteFutbolistas.Instance.BuscarPorValor(decimal.Parse(txtBoxValor.Text)));
                    }
                }
            }
            // Realiza la intersección de las listas para obtener el resultado final.
            if (listaListas.Count > 0)
            {
                jugadoresBuscados = listaListas.Aggregate((interseccion, lista) => interseccion.Intersect(lista).ToList());
            }
            else
            {
                jugadoresBuscados.AddRange(ClienteFutbolistas.Instance.GetAll());
            }
            return jugadoresBuscados;
        }
        /// <summary>
        /// Genera la lista de enlace de datos y la asocia con el control DataGridView.
        /// </summary>
        private void GenerarBidingList()
        {
            listaJugadores = new BindingList<Jugador>(ClienteFutbolistas.Instance.GetAll());
            dgvTabla.DataSource = listaJugadores;
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[dgvTabla.Columns.Count - 1].Visible = false;
            dgvTabla.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto de búsqueda, realizando la búsqueda al presionar Enter.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="KeyPressEventArgs"/> que contiene los datos del evento.</param>
        private void txtBoxBuscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        /// <summary>
        /// Maneja el evento KeyDown del cuadro de texto de búsqueda, realizando la búsqueda al presionar Enter.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="KeyEventArgs"/> que contiene los datos del evento.</param>
        private void txtBoxBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        /// <summary>
        /// Maneja el evento SelectionChanged del control DataGridView, actualizando los detalles del jugador seleccionado.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void dgvTabla_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTabla.CurrentCell != null)
            {
                int indiceFila = dgvTabla.CurrentCell.RowIndex;

                if (indiceFila >= 0 && indiceFila < dgvTabla.Rows.Count)
                {
                    DataGridViewRow filaSeleccionada = dgvTabla.Rows[indiceFila];
                    JugadorSeleccionado = (Jugador)filaSeleccionada.DataBoundItem;
                    DatosJugador.CambiarDatos(JugadorSeleccionado);
                }
                else
                {
                    DatosJugador.LimpiarDatos();
                }
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón "Vender", abriendo una ventana de venta.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            if (JugadorSeleccionado!=null)
            {
                VentanaVenta ventanaVenta = new VentanaVenta(this);
                ventanaVenta.StartPosition = FormStartPosition.CenterParent;
                ventanaVenta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un jugador antes");
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón "Renovar", abriendo una ventana de renovación o creación de jugador.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnRenovar_Click(object sender, EventArgs e)
        {
            if (JugadorSeleccionado != null)
            {
                VentanaRenovarCrear ventanaRenovar = new VentanaRenovarCrear(this, JugadorSeleccionado);
                ventanaRenovar.StartPosition = FormStartPosition.CenterParent;
                ventanaRenovar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un jugador antes");
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón "Nuevo Jugador", abriendo una ventana de renovación o creación de jugador.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void btnNuevoJugador_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la ventana de renovación o creación de jugador.
            VentanaRenovarCrear ventanaCrear = new VentanaRenovarCrear(this);
            ventanaCrear.StartPosition = FormStartPosition.CenterParent;
            ventanaCrear.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento KeyDown del cuadro de texto, realizando la búsqueda al presionar Enter.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="KeyEventArgs"/> que contiene los datos del evento.</param>
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
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
    }
}
