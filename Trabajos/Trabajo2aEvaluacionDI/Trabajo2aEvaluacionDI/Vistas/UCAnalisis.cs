using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Trabajo2aEvaluacionDI.Conexion;
using Trabajo2aEvaluacionDI.Modelos;

namespace Trabajo2aEvaluacionDI.Vistas
{
    /// <summary>
    /// Clase que representa un control de usuario para el análisis y visualización de transacciones.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCAnalisis : UserControl
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCAnalisis"/>.
        /// </summary>
        public UCAnalisis()
        {
            InitializeComponent();
            ActualizarSaldo();
            ModificacionesChart();
            ActualizarGrafica();
        }
        /// <summary>
        /// Actualiza el saldo mostrado en la interfaz gráfica.
        /// </summary>
        public void ActualizarSaldo()
        {
            lblSaldo.Text = ClienteTransacciones.Instance.GetSaldoActual().ToString();
        }
        /// <summary>
        /// Realiza modificaciones en el gráfico, estableciendo configuraciones específicas.
        /// </summary>
        public void ModificacionesChart()
        {
            chartLineas.ChartAreas[0].Name = "SaldosActuales";
            chartLineas.ChartAreas[0].AxisX.Title = "Jugadores";
            chartLineas.ChartAreas[0].AxisY.Title = "Saldo";
            chartLineas.ChartAreas[0].InnerPlotPosition.Auto = true;
            chartLineas.ChartAreas[0].AxisX.Interval = 1;
        }
        /// <summary>
        /// Actualiza la gráfica con los datos de las transacciones.
        /// </summary>
        public void ActualizarGrafica()
        {
            List<Transaccion> listaTransacciones = ClienteTransacciones.Instance.GetAll();
            List<string> listaNombres = listaTransacciones.Select(x => x.JugadorNombre).ToList();
            List<decimal> valoresSaldo = listaTransacciones.Select(x => x.Saldo_Actual).ToList();

            chartLineas.Series.Clear();
            Series series = new Series("Evolucion Salarial");
            series.ChartType = SeriesChartType.SplineArea;
            series.BorderWidth = 2;
            for (int i = 0; i < listaNombres.Count; i++)
            {
                series.Points.AddXY(listaNombres[i], valoresSaldo[i]);
                if (i != 0)
                {
                    if (valoresSaldo[i] < valoresSaldo[i - 1])
                    {
                        series.Points[i].Color = System.Drawing.Color.Red;
                    }
                    else
                    {
                        series.Points[i].Color = System.Drawing.Color.LawnGreen;
                    }
                }
            }
            chartLineas.Series.Add(series);
            chartLineas.Update();
        }

        /// <summary>
        /// Maneja el evento Click del botón en la interfaz gráfica, actualizando el saldo y la gráfica.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarSaldo();
            ActualizarGrafica();
        }

    }
}
