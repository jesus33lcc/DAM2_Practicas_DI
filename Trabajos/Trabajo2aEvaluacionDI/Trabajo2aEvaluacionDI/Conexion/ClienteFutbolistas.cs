using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Modelos;
using Trabajo2aEvaluacionDI.Utils;

namespace Trabajo2aEvaluacionDI.Conexion
{
    /// <summary>
    /// Cliente para interactuar con la base de datos de futbolistas.
    /// </summary>
    /// <seealso cref="Trabajo2aEvaluacionDI.Conexion.InterfazDatos&lt;Trabajo2aEvaluacionDI.Modelos.Jugador&gt;" />
    public class ClienteFutbolistas : InterfazDatos<Jugador>
    {
        /// <summary>
        /// La instancia unica del cliente.
        /// </summary>
        private static ClienteFutbolistas _instance;
        /// <summary>
        /// Evita la creación de una instancia predeterminada de la clase <see cref="ClienteFutbolistas"/>
        /// </summary>
        private ClienteFutbolistas()
        {
        }
        /// <summary>
        /// Obtiene la instancia única del cliente.
        /// </summary>
        /// <value>
        /// La instancia
        /// </value>
        public static ClienteFutbolistas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteFutbolistas();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Obtiene todos los elementos.
        /// </summary>
        /// <returns>
        /// Lista de elementos del tipo especificado.
        /// </returns>
        public List<Jugador> GetAll()
        {
            List<Jugador> listaJugadores = new List<Jugador>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand comando = conn.CreateCommand();
                    comando.CommandText = $"SELECT * FROM {Constantes.NOMBRE_TABLA_FUTBOLISTAS}";

                    MySqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Jugador jugador = new Jugador
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Pais = lector.GetString(2),
                            Club = lector.GetString(3),
                            Valor = lector.GetDecimal(4),
                            IdTransfermarkt = lector.GetInt32(5)
                        };
                        listaJugadores.Add(jugador);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listaJugadores;
        }
        /// <summary>
        /// Busca jugadores que coincidan con un valor y un campo específicos.
        /// </summary>
        /// <param name="value">Valor a buscar.</param>
        /// <param name="field">Campo en el que buscar.</param>
        /// <returns>Lista de jugadores que coinciden con la búsqueda.</returns>
        public List<Jugador> BuscarPor(string valor, string campo)
        {
            List<Jugador> listaJugadores = new List<Jugador>();
            valor = "%" + valor + "%";
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM {Constantes.NOMBRE_TABLA_FUTBOLISTAS} WHERE {campo} LIKE @valor";
                    cmd.Parameters.AddWithValue("@valor", valor);
                    MySqlDataReader lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        Jugador jugador = new Jugador
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Pais = lector.GetString(2),
                            Club = lector.GetString(3),
                            Valor = lector.GetDecimal(4),
                            IdTransfermarkt = lector.GetInt32(5)
                        };
                        listaJugadores.Add(jugador);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listaJugadores;
        }
        /// <summary>
        /// Busca jugadores que tengan un valor específico.
        /// </summary>
        /// <param name="valor">Valor a buscar.</param>
        /// <returns>Lista de jugadores que coinciden con la búsqueda.</returns>
        public List<Jugador> BuscarPorValor(decimal valor)
        {
            List<Jugador> listaJugadores = new List<Jugador>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM {Constantes.NOMBRE_TABLA_FUTBOLISTAS} WHERE {Constantes.NOMBRE_CAMPO_VALOR} = @valor";
                    cmd.Parameters.AddWithValue("@valor", valor);
                    MySqlDataReader lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        Jugador jugador = new Jugador
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Pais = lector.GetString(2),
                            Club = lector.GetString(3),
                            Valor = lector.GetDecimal(4),
                            IdTransfermarkt = lector.GetInt32(5)
                        };
                        listaJugadores.Add(jugador);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listaJugadores;
        }
        /// <summary>
        /// Inserta un nuevo elemento.
        /// </summary>
        /// <param name="data">Elemento a insertar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        public bool Insert(Jugador data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO {Constantes.NOMBRE_TABLA_FUTBOLISTAS} " +
                        $"({Constantes.NOMBRE_CAMPO_NOMBRE}, {Constantes.NOMBRE_CAMPO_PAIS}, " +
                        $"{Constantes.NOMBRE_CAMPO_CLUB}, {Constantes.NOMBRE_CAMPO_VALOR}, " +
                        $"{Constantes.NOMBRE_CAMPO_IDTRANSFERMARKT}) VALUES (@Nombre, @Pais, @Club, @Valor, @IdTransfermarkt)";
                    cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
                    cmd.Parameters.AddWithValue("@Pais", data.Pais);
                    cmd.Parameters.AddWithValue("@Club", data.Club);
                    cmd.Parameters.AddWithValue("@Valor", data.Valor);
                    cmd.Parameters.AddWithValue("@IdTransfermarkt", data.IdTransfermarkt);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Actualiza un elemento existente.
        /// </summary>
        /// <param name="data">Elemento a actualizar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        public bool Update(Jugador data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"UPDATE {Constantes.NOMBRE_TABLA_FUTBOLISTAS} " +
                        $"SET {Constantes.NOMBRE_CAMPO_NOMBRE} = @Nombre, {Constantes.NOMBRE_CAMPO_PAIS} = @Pais, " +
                        $"{Constantes.NOMBRE_CAMPO_CLUB} = @Club, {Constantes.NOMBRE_CAMPO_VALOR} = @Valor " +
                        $"WHERE {Constantes.NOMBRE_CAMPO_ID} = @Id";
                    cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
                    cmd.Parameters.AddWithValue("@Pais", data.Pais);
                    cmd.Parameters.AddWithValue("@Club", data.Club);
                    cmd.Parameters.AddWithValue("@Valor", data.Valor);
                    cmd.Parameters.AddWithValue("@Id", data.Id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Elimina un elemento.
        /// </summary>
        /// <param name="data">Elemento a eliminar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        public bool Delete(Jugador data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"DELETE FROM {Constantes.NOMBRE_TABLA_FUTBOLISTAS} WHERE {Constantes.NOMBRE_CAMPO_ID} = @id";
                    cmd.Parameters.AddWithValue("@id", data.Id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Verifica si un jugador ya existe en la base de datos.
        /// </summary>
        /// <param name="data">Jugador a verificar.</param>
        /// <returns>True si el jugador ya existe, False en caso contrario.</returns>
        public bool Exist(Jugador data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT COUNT(*) FROM {Constantes.NOMBRE_TABLA_FUTBOLISTAS}" +
                        $" WHERE {Constantes.NOMBRE_CAMPO_NOMBRE} = @Nombre AND {Constantes.NOMBRE_CAMPO_PAIS} = @Pais " +
                        $"AND {Constantes.NOMBRE_CAMPO_CLUB} = @Club AND {Constantes.NOMBRE_CAMPO_VALOR} = @Valor";
                    cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
                    cmd.Parameters.AddWithValue("@Pais", data.Pais);
                    cmd.Parameters.AddWithValue("@Club", data.Club);
                    cmd.Parameters.AddWithValue("@Valor", data.Valor);

                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return cantidad > 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
