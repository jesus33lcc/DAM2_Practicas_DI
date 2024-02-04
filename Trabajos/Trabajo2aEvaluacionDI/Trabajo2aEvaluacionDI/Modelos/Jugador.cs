using System;

namespace Trabajo2aEvaluacionDI.Modelos
{

    /// <summary>
    /// Clase que representa a un jugador de fútbol.
    /// </summary>
    /// <seealso cref="System.IComparable&lt;Trabajo2aEvaluacionDI.Modelos.Jugador&gt;" />
    public class Jugador : IComparable<Jugador>
    {
        /// <summary>
        /// Obtiene o establece el identificador del jugador.
        /// </summary>
        /// <value>
        /// El identificador del jugador
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        /// <value>
        /// El nombre del jugador
        /// </value>
        public string Nombre { get; set; }
        /// <summary>
        /// Obtiene o establece el país del jugador.
        /// </summary>
        /// <value>
        /// El país del jugador
        /// </value>
        public string Pais { get; set; }
        /// <summary>
        /// Obtiene o establece el club del jugador.
        /// </summary>
        /// <value>
        /// El club del jugador
        /// </value>
        public string Club { get; set; }
        /// <summary>
        /// Obtiene o establece el valor del jugador.
        /// </summary>
        /// <value>
        /// El valor del jugador
        /// </value>
        public decimal Valor { get; set; }
        /// <summary>
        /// Obtiene o establece el identificador Transfermarkt del jugador.
        /// </summary>
        /// <value>
        /// El identificador del jugador en Transfermarkt
        /// </value>
        public int? IdTransfermarkt { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase  <see cref="Jugador"/>
        /// </summary>
        public Jugador() { }

        /// <summary>
        /// Determina si el <see cref="System.Object" /> especificado es igual a la instancia actual.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> a comparar con esta instancia.</param>
        /// <returns>
        ///   <c>true</c> si el <see cref="System.Object" /> especificado es igual a la instancia actual; de lo contrario, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Jugador jugador &&
                   Id == jugador.Id;
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

        /// <summary>
        /// Compara la instancia actual con otro objeto del mismo tipo y devuelve un entero que indica si la posición de la instancia actual es anterior, posterior o igual que la del otro objeto en el criterio de ordenación.
        /// </summary>
        /// <param name="other">Objeto que se va a comparar con esta instancia.</param>
        /// <returns>
        /// Un valor que indica el orden relativo de los objetos que se están comparando.
        /// El valor devuelto tiene los siguientes significados:
        /// Valor
        /// Significado
        /// Menor que cero
        /// Esta instancia es anterior a <paramref name="other" /> en el criterio de ordenación.
        /// Cero
        /// Esta instancia se produce en la misma posición en el criterio de ordenación <paramref name="other" />.
        /// Mayor que cero
        /// Esta instancia sigue a <paramref name="other" /> en el criterio de ordenación.
        /// </returns>
        public int CompareTo(Jugador other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
