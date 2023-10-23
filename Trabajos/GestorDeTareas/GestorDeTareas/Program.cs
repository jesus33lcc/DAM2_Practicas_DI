using GestorDeTareas;
using System;

class Program
{
    static void Main()
    {
        Helper Ayuda = new Helper();
        Console.WriteLine("Aplicación de Gestión de Tareas");
        string respuesta;
        do
        {
            Ayuda.Menu();
            respuesta = Console.ReadLine().Trim();
            switch (respuesta)
            {
                case "1":
                    Ayuda.ListarListasFiltradas(1);
                    break;
                case "2":
                    Ayuda.ListarListasFiltradas(2);
                    break;
                case "3":
                    Ayuda.ListarListasFiltradas(3);
                    break;
                case "4":
                    Ayuda.AgregarNuevaTarea();
                    break;
                case "5":
                    Ayuda.MarcarTareaComoCompletada();
                    break;
                case "6":
                    Ayuda.GuardarTareasEnArchivo();
                    break;
                case "7":
                    Ayuda.CargarTareasDesdeArchivo();
                    break;
                case "8":
                    Console.WriteLine("ADIOS");
                    break;
                default:
                    Console.WriteLine("Introduzca una respuesta valida");
                    break;
            }
        } while (respuesta != "8");
    }
}