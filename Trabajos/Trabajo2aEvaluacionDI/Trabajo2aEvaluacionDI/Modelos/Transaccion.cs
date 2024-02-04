
namespace Trabajo2aEvaluacionDI.Modelos
{
    /// <summary>
    /// Clase que representa una transacción relacionada con un jugador de fútbol.
    /// </summary>
    public class Transaccion
    {
        /// <summary>
        /// Obtiene o establece el identificador de la transacción.
        /// </summary>
        /// <value>
        /// El identificador de la transaccion.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del jugador asociado a la transacción.
        /// </summary>
        /// <value>
        /// El nombre del jugador de la transaccion.
        /// </value>
        public string JugadorNombre { get; set; }
        /// <summary>
        /// Obtiene o establece el monto de ingresos de la transacción.
        /// </summary>
        /// <value>
        /// Los ingresos de la transaccion.
        /// </value>
        public decimal Ingresos { get; set; }
        /// <summary>
        /// Obtiene o establece el monto de gastos de la transacción.
        /// </summary>
        /// <value>
        /// Los gastos de la transaccion.
        /// </value>
        public decimal Gastos { get; set; }
        /// <summary>
        /// Obtiene o establece el saldo actual después de la transacción.
        /// </summary>
        /// <value>
        /// El saldo actual de la transaccion.
        /// </value>
        public decimal Saldo_Actual { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Transaccion"/>
        /// </summary>
        public Transaccion() { }

        /// <summary>
        /// Determina si el <see cref="System.Object" /> especificado es igual a la instancia actual.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> a comparar con esta instancia.</param>
        /// <returns>
        ///   <c>true</c> si el <see cref="System.Object" /> especificado es igual a la instancia actual; de lo contrario, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Transaccion transaccion &&
                   Id == transaccion.Id;
        }

        /// <summary>
        /// Devuelve un código hash para esta instancia.
        /// </summary>
        /// <returns>
        /// Un código hash para esta instancia, adecuado para usar en algoritmos de hash y estructuras de datos como una tabla hash.
        /// </returns>
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
