using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.UTILS
{
    internal class FilesUtils
    {
        public static void CargarHistorico(ListBox listBox)
        {
            string[] registros = File.ReadAllLines(Constantes.RUTA_HISTORICO);
            foreach (string resgitro in registros)
            {
                listBox.Items.Add(resgitro);
            }
        }
        public static void GuardarRegistro(String registro)
        {
            File.AppendAllText(Constantes.RUTA_HISTORICO, registro + Environment.NewLine);
        }
    }
}
