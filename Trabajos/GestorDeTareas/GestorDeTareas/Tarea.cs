using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    [Serializable]
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completado { get; set; }
        public int Codigo { get; set; }

        public Tarea(string descripcion, DateTime fechaVencimiento, int codigo)
        {
            Descripcion = descripcion;
            FechaVencimiento = fechaVencimiento;
            Completado = false;
            Codigo = codigo;
        }
        public Tarea()
        {

        }
        public override string ToString()
        {
            return (Codigo+". "+Descripcion+"\tFecha de Vencimiento: "+FechaVencimiento+"\tEstado: "+Completado);
        }
    }
}
