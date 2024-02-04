
namespace Trabajo2aEvaluacionDI.Utils
{
    /// <summary>
    /// Clase que contiene constantes utilizadas en la aplicación.
    /// </summary>
    public class Constantes
    {
        /// <summary>
        /// Cadena de conexión a la base de datos de fútbol.
        /// </summary>
        public const string CONEXION_BDFUTBOL = "server=localhost;port=6969;uid=root;pwd=password;database=bDFutbol;";
        /// <summary>
        /// Nombre de la tabla de futbolistas en la base de datos.
        /// </summary>
        
        //Tabla Futbolistas:
        
        public const string NOMBRE_TABLA_FUTBOLISTAS = "Futbolistas";
        /// <summary>
        /// Nombre del campo identificador en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_ID = "Id";
        /// <summary>
        /// Nombre del campo nombre en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_NOMBRE = "Nombre";
        /// <summary>
        /// Nombre del campo país en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_PAIS = "Pais";
        /// <summary>
        /// Nombre del campo club en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_CLUB = "Club";
        /// <summary>
        /// Nombre del campo valor en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_VALOR = "Valor";
        /// <summary>
        /// Nombre del campo ID Transfermarkt en la tabla de futbolistas.
        /// </summary>
        public const string NOMBRE_CAMPO_IDTRANSFERMARKT = "IdTransfermarkt";

        //Tabla Transacciones:

        /// <summary>
        /// Nombre de la tabla de transacciones en la base de datos.
        /// </summary>
        public const string NOMBRE_TABLA_TRANSACCIONES = "Transacciones";
        /// <summary>
        /// Nombre del campo saldo actual en la tabla de transacciones.
        /// </summary>
        public const string NOMBRE_CAMPO_SALDO_ACTUAL = "Saldo_Actual";
        /// <summary>
        /// Nombre del campo nombre del jugador en la tabla de transacciones.
        /// </summary>
        public const string NOMBRE_CAMPO_JUGADOR_NOMBRE = "Jugador";
        /// <summary>
        /// Nombre del campo ingresos en la tabla de transacciones.
        /// </summary>
        public const string NOMBRE_CAMPO_INGRESOS = "Ingresos";
        /// <summary>
        /// Nombre del campo gastos en la tabla de transacciones.
        /// </summary>
        public const string NOMBRE_CAMPO_GASTOS = "Gastos";

    }
}
