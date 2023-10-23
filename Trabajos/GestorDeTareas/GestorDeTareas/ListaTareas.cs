using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public List<Tarea> ListaDeTareasFiltrada(int numeroMenu)
        {
            List<Tarea> ListaFiltrada = new List<Tarea>();
            switch (numeroMenu)
            {
                case 1:
                    ListaFiltrada = ListaDeTareas.Where(tarea => tarea.Completado == false).ToList();
                    break;
                case 2:
                    ListaFiltrada = ListaDeTareas.Where(tarea => tarea.Completado == false).ToList();
                    break;
                case 3:
                    ListaFiltrada = ListaDeTareas.OrderBy(tarea => tarea.FechaVencimiento).ToList();
                    break;
                default:
                    break;
            }
            return ListaFiltrada;
        }
    }
}
