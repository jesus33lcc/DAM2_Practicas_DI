using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Modelos;

namespace Trabajo2aEvaluacionDI.Elementos
{
    /// <summary>
    /// Control de usuario que muestra el perfil de un jugador.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCPerfil : UserControl
    {
        /// <summary>
        /// Obtiene o establece el objeto Jugador asociado al perfil.
        /// </summary>
        /// <value>
        /// El jugador.
        /// </value>
        public Jugador Jugador { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCPerfil"/>.
        /// </summary>
        public UCPerfil()
        {
            InitializeComponent();
            LimpiarDatos();
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCPerfil"/> con un jugador específico.
        /// </summary>
        /// <param name="jugador">El Jugador que se asociará al perfil.</param>
        public UCPerfil(Jugador jugador)
        {
            Jugador = jugador;
            lblNombre.Text = Jugador.Nombre;
            lblClub.Text = Jugador.Club;
            lblPais.Text = Jugador.Pais;
            lblValor.Text = Jugador.Valor.ToString();
        }
        /// <summary>
        /// Cambia los datos del perfil con la información de un nuevo jugador.
        /// </summary>
        /// <param name="jugador">Nuevo Jugador para mostrar en el perfil.</param>
        public void CambiarDatos(Jugador jugador)
        {
            Jugador = jugador;
            lblNombre.Text = Jugador.Nombre;
            lblClub.Text = Jugador.Club;
            lblPais.Text = Jugador.Pais;
            lblValor.Text = Jugador.Valor.ToString();
        }
        /// <summary>
        /// Limpia los datos del perfil, mostrando valores vacíos.
        /// </summary>
        public void LimpiarDatos()
        {
            lblNombre.Text = string.Empty;
            lblClub.Text = string.Empty;
            lblPais.Text = string.Empty;
            lblValor.Text = string.Empty;
        }
    }
}
