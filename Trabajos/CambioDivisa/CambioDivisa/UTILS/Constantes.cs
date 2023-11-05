using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.UTILS
{
    public class Constantes
    {
        public const string RUTA_HISTORICO = "Historico.txt";
        public const decimal EURO_A_DOLAR = 1.05m;
        public const decimal LIBRA_A_DOLAR = 1.30m;
        public const decimal DOLAR_A_EURO = 1/EURO_A_DOLAR;
        public const decimal DOLAR_A_LIBRA = 1/LIBRA_A_DOLAR;
    }
}
