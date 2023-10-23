using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    [Serializable]
    public class ListaTareas
    {
        public List<Tarea> ListaDeTareas { get; set; }

        public ListaTareas()
        {
            ListaDeTareas = new List<Tarea>();
        }

        public ListaTareas(List<Tarea> listaDeTareas)
        {
            ListaDeTareas = listaDeTareas;
        }

        public void AgregarTarea(Tarea tarea)
        {
            ListaDeTareas.Add(tarea);
        }
        public void EliminarTarea()
        {

        }
        public List<Tarea> TodasLasTareas()
        {
            return ListaDeTareas;
        }
        public List<Tarea> TareasIncompletas()
        {
            return ListaDeTareas.Where(tarea => tarea.Completado == false).ToList();
        }
        public List<Tarea> TareasOrdenadoPorFech_Venc()
        {
            return ListaDeTareas.OrderBy(tarea => tarea.FechaVencimiento).ToList();

        }
    }
}
