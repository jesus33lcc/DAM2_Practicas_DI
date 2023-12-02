using GestorDeArchivos.Utils;

namespace GestorDeArchivos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (!Directory.Exists(Constantes.FILES))
            {
                Directory.CreateDirectory(Constantes.FILES);
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            
            //A�adir imagen a info
            //A�adir texto a info
            //


        }
    }
}