using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    public static class Logger
    {
        public static void EscribirEnLogFile(string mensaje)
        {
            string RutaLogFile = "LogFile.txt";
            try
            {
                using (StreamWriter escritor = new StreamWriter(RutaLogFile, true))
                {
                    escritor.WriteLine(DateTime.Now + ": " + mensaje);
                    escritor.Close();
                    Console.WriteLine("Ha habido un error, revisa el LogFile");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir en el archivo de registro: " + ex.Message);
                //EscribirEnLogFile(ex.Message);
            }
        }
    }
}
