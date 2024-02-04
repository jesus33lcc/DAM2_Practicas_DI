using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo2aEvaluacionDI.Modelos;
using Trabajo2aEvaluacionDI.Utils;

namespace Trabajo2aEvaluacionDI.Conexion
{
    /// <summary>
    /// Cliente para interactuar con la base de datos de transacciones.
    /// </summary>
    /// <seealso cref="Trabajo2aEvaluacionDI.Conexion.InterfazDatos&lt;Trabajo2aEvaluacionDI.Modelos.Transaccion&gt;" />
    public class ClienteTransacciones : InterfazDatos<Transaccion>
    {
        /// <summary>
        /// Instancia única del cliente.
        /// </summary>
        private static ClienteTransacciones _instance;
        /// <summary>
        /// Evita la creación de una instancia predeterminada de la clase <see cref="ClienteTransacciones"/>
        /// </summary>
        private ClienteTransacciones()
        {
        }
        /// <summary>
        /// Obtiene la instancia única del cliente.
        /// </summary>
        /// <value>
        /// La instancia.
        /// </value>
        public static ClienteTransacciones Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteTransacciones();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene el saldo actual.
        /// </summary>
        /// <returns>Saldo actual.</returns>
        public decimal GetSaldoActual()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT {Constantes.NOMBRE_CAMPO_SALDO_ACTUAL} " +
                        $"FROM {Constantes.NOMBRE_TABLA_TRANSACCIONES} ORDER BY {Constantes.NOMBRE_CAMPO_ID} DESC LIMIT 1;";
                    decimal saldoActual = Convert.ToDecimal(cmd.ExecuteScalar());
                    conn.Close();
                    return saldoActual;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// Obtiene todas las transacciones de la base de datos.
        /// </summary>
        /// <returns>Lista de transacciones.</returns>
        public List<Transaccion> GetAll()
        {
            List<Transaccion> listaTransacciones = new List<Transaccion>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand comando = conn.CreateCommand();
                    comando.CommandText = $"SELECT * FROM {Constantes.NOMBRE_TABLA_TRANSACCIONES}";

                    MySqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Transaccion transaccion = new Transaccion
                        {
                            Id = lector.GetInt32(0),
                            JugadorNombre = lector.GetString(1),
                            Ingresos = lector.GetDecimal(2),
                            Gastos = lector.GetDecimal(3),
                            Saldo_Actual = lector.GetDecimal(4)
                        };
                        listaTransacciones.Add(transaccion);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listaTransacciones;
        }
        /// <summary>
        /// Inserta una nueva transacción en la base de datos.
        /// </summary>
        /// <param name="data">Transacción a insertar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        public bool Insert(Transaccion data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constantes.CONEXION_BDFUTBOL;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO {Constantes.NOMBRE_TABLA_TRANSACCIONES} " +
                        $"({Constantes.NOMBRE_CAMPO_JUGADOR_NOMBRE}, {Constantes.NOMBRE_CAMPO_INGRESOS}," +
                        $" {Constantes.NOMBRE_CAMPO_GASTOS}, {Constantes.NOMBRE_CAMPO_SALDO_ACTUAL})" +
                        $" VALUES (@JugadorNombre, @Ingresos, @Gastos, @SaldoActual)";
                    cmd.Parameters.AddWithValue("@JugadorNombre", data.JugadorNombre);
                    cmd.Parameters.AddWithValue("@Ingresos", data.Ingresos);
                    cmd.Parameters.AddWithValue("@Gastos", data.Gastos);
                    cmd.Parameters.AddWithValue("@SaldoActual", data.Saldo_Actual);
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
        /// Actualiza una transacción existente en la base de datos.
        /// </summary>
        /// <param name="data">Transacción  a actualizar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Update(Transaccion data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina una transacción de la base de datos.
        /// </summary>
        /// <param name="data">Transacción  a eliminar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False en caso contrario.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Delete(Transaccion data)
        {
            throw new NotImplementedException();
        }
    }
}
