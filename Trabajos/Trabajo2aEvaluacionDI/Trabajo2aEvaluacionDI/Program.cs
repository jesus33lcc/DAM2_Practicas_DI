using System;
using System.Windows.Forms;

namespace Trabajo2aEvaluacionDI
{
    /// <summary>
    /// Clase principal del programa que contiene el punto de entrada.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita los estilos visuales de la aplicación.
            Application.EnableVisualStyles();
            // Establece la propiedad predeterminada para la representación de texto compatible.
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia la aplicación ejecutando la ventana principal (Main).
            Application.Run(new Main());
        }
    }
}
