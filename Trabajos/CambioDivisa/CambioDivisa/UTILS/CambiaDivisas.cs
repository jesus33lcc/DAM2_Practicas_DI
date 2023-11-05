using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.UTILS
{
    internal class CambiaDivisas
    {
        public static decimal CambioDivisa(decimal cantidad, string origen, string destino)
        {
            Dictionary<string, decimal> divisas = new Dictionary<string, decimal>
            {
                {"EurosDollars",cantidad*Constantes.EURO_A_DOLAR},
                {"LibrasDollars",cantidad*Constantes.LIBRA_A_DOLAR},
                {"DollarsEuros", cantidad*Constantes.DOLAR_A_EURO},
                {"DollarsLibras", cantidad*Constantes.DOLAR_A_LIBRA},
                {"EurosLibras", (cantidad * Constantes.EURO_A_DOLAR)/Constantes.LIBRA_A_DOLAR},
                {"LibrasEuros", (cantidad*Constantes.LIBRA_A_DOLAR)/Constantes.EURO_A_DOLAR}
            };
            string cambio = origen + destino;
            return divisas[cambio];
        }
    }
}
