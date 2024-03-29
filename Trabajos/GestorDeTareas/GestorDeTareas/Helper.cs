﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GestorDeTareas
{
    public class Helper
    {
        private ListaTareas Modelo = new ListaTareas();
        private string Ruta_Lectura = "";
        private string Ruta_Escritura = "";
        

        public void Menu()
        {
            WriteLineGreen("\tSelecciona una opción:");
            WriteLineGreen("\t1. Listar todas las tareas");
            WriteLineGreen("\t2. Listar tareas incompletas");
            WriteLineGreen("\t3. Listar tareas por fecha de vencimiento");
            WriteLineGreen("\t4. Agregar nueva tarea");
            WriteLineGreen("\t5. Marcar tarea como completada");
            WriteLineGreen("\t6. Guardar tareas en archivo");
            WriteLineGreen("\t7. Cargar tareas desde archivo");
            WriteLineRed("\t8. Salir");
        }
        public void ListarListasFiltradas(int numeroMenu)
        {
            List<Tarea> ListaParaListar= new List<Tarea>();
            switch (numeroMenu)
            {
                case 1:
                    ListaParaListar = Modelo.ListaDeTareasFiltrada(1);
                    break;
                case 2:
                    ListaParaListar = Modelo.ListaDeTareasFiltrada(2);
                    break;
                case 3:
                    ListaParaListar = Modelo.ListaDeTareasFiltrada(3);
                    break;
                default:
                    break;
            }
            if (ListaParaListar.Count != 0)
            {
                ListaParaListar.ForEach(tarea =>
                {
                    WriteLineCyan(tarea.ToString());
                });
            }
            else
            {
                WriteLineRed("No hay ninguna tarea");
            }
        }
        
        public void AgregarNuevaTarea()
        {
            WriteLineGreen("Escriba la descripción de la tarea:");
            string Descripcion = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                Descripcion = "(Tarea sin descripción)";
            }

            DateTime fechaConFormato;
            do
            {
                WriteLineCyan("Ingrese la fecha de vencimiento en formato dd/MM/yyyy: ");
                string Fecha = Console.ReadLine();
                if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaConFormato))
                {
                    if (fechaConFormato < DateTime.Now)
                    {
                        WriteLineRed("La fecha no es válida, vuelva a escribir una fecha posterior a la actual.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    WriteLineRed("Formato incorrecto, introduzca la fecha con el formato correcto");
                }
            } while (true);
            Modelo.AgregarTarea(new Tarea(Descripcion, fechaConFormato, Modelo.ListaDeTareas.Count + 1));
            WriteLineGreen("La tarea ha sido añadida correctamente");
        }
        public void MarcarTareaComoCompletada()
        {
            if (Modelo.ListaDeTareas.Count != 0)
            {
                ListarListasFiltradas(2);
                WriteLineCyan("Escribe el numero de la tarea que quieras marcar");
                do
                {
                    int Numero;
                    string Linea = Console.ReadLine().Trim();
                    if (int.TryParse(Linea, out Numero))
                    {
                        var TareaParaMarcar = Modelo.ListaDeTareasFiltrada(2).Find(tarea => tarea.Codigo == Numero);
                        if (TareaParaMarcar == null)
                        {
                            WriteLineRed("Numero no valido, escriba un numero de la lista");
                        }
                        else
                        {
                            TareaParaMarcar.Completado = true;
                            WriteLineGreen("La tarea ha sido marcada");
                            break;
                        }
                    }
                    else
                    {
                        WriteLineRed("No has escrito un numero");
                    };
                } while (true);
            }
            else
            {
                WriteLineRed("La lista de Tareas esta vacia, añada alguna Tarea o cargue un archivo");
            }
        }
        public void GuardarTareasEnArchivo()
        {
            if (Modelo.ListaDeTareas.Count != 0)
            {
                WriteLineCyan("¿En que formato quieres guardarlo: JSON o XMl?");
                while (true)
                {
                    string formato = Console.ReadLine().Trim().ToLower();
                    if (formato.Equals("json"))
                    {
                        EscribirEnJson();
                        WriteLineGreen("Archivo guardado correctamente");
                        break;
                    }
                    else if (formato.Equals("xml"))
                    {
                        EscribirEnXml();
                        WriteLineGreen("Archivo guardado correctamente");
                        break;
                    }
                    else
                    {
                        WriteLineRed("No valido. Escriba JSON o XML");
                    }
                }
            }
            else
            {
                WriteLineRed("La lista de Tareas esta vacia, añada alguna Tarea o cargue un archivo");
            }
        }
        public void CargarTareasDesdeArchivo()
        {
            WriteLineCyan("¿En que formato quieres leer: JSON o XMl?");
            while (true)
            {
                string formato = Console.ReadLine().Trim().ToLower();
                if (formato.Equals("json"))
                {
                    SeleccionArchivo(".json");
                    LeerEnJson();
                    break;
                }
                else if (formato.Equals("xml"))
                {
                    SeleccionArchivo(".xml");
                    LeerEnXml();
                    break;
                }
                else
                {
                    WriteLineRed("No valido. Escriba JSON o XML");
                }
            }
        }
        public async Task LeerEnJson()
        {
            try
            {
                string ListaTareaJson = await File.ReadAllTextAsync(Ruta_Lectura);
                Modelo = JsonSerializer.Deserialize<ListaTareas>(ListaTareaJson);
                WriteLineGreen($"Archivo {Ruta_Lectura} cargado correctamenta");
            }
            catch (FileNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El archivo no se encontró: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El directorio no se encontró: " + ex.Message);
            }
            catch (IOException ex)
            {
                Logger.EscribirEnLogFile("Error al leer el archivo: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.EscribirEnLogFile("No tienes permisos para acceder al archivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirEnLogFile("Error desconocido: " + ex.Message);
            }
        }

        public async Task EscribirEnJson()
        {
            try
            {
                string ListaTareaJson = JsonSerializer.Serialize(Modelo);
                await File.WriteAllTextAsync(RutaEscribir(".json"), ListaTareaJson);
            }
            catch (FileNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El archivo no se encontró: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El directorio no se encontró: " + ex.Message);
            }
            catch (IOException ex)
            {
                Logger.EscribirEnLogFile("Error al leer el archivo: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.EscribirEnLogFile("No tienes permisos para acceder al archivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirEnLogFile("Error desconocido: " + ex.Message);
            }
        }
        public async Task LeerEnXml()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListaTareas));
                using (StreamReader reader = new StreamReader(Ruta_Lectura))
                {
                    Modelo = (ListaTareas)xmlSerializer.Deserialize(reader);
                    WriteLineGreen($"Archivo cargado correctamente en : {Ruta_Lectura}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El archivo no se encontró: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El directorio no se encontró: " + ex.Message);
            }
            catch (IOException ex)
            {
                Logger.EscribirEnLogFile("Error al leer el archivo: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.EscribirEnLogFile("No tienes permisos para acceder al archivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirEnLogFile("Error desconocido: " + ex.Message);
            }
        }
        public void EscribirEnXml()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListaTareas));
                using (TextWriter textWriter = new StreamWriter(RutaEscribir(".xml")))
                {
                    xmlSerializer.Serialize(textWriter, Modelo);
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El archivo no se encontró: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.EscribirEnLogFile("El directorio no se encontró: " + ex.Message);
            }
            catch (IOException ex)
            {
                Logger.EscribirEnLogFile("Error al leer el archivo: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.EscribirEnLogFile("No tienes permisos para acceder al archivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirEnLogFile("Error desconocido: " + ex.Message);
            }
        }
        public void SeleccionArchivo(string extension)
        {
            WriteLineCyan("Escriba la ruta del archivo");
            string rutaArchivo = Console.ReadLine().Trim();
                while (true)
                {
                    if (!File.Exists(rutaArchivo))
                    {
                        WriteLineRed("El archivo no existe. Escriba una ruta valida");
                        rutaArchivo = Console.ReadLine().Trim();
                    }
                    else if (!rutaArchivo.EndsWith(extension))
                    {
                        WriteLineRed($"Archivo incompatible, eliga un archivo con extension {extension}");
                    }
                    else
                    {
                        break;
                    }
                    rutaArchivo = Console.ReadLine().Trim();
                }
                Ruta_Lectura = rutaArchivo;
        }
        
        public string RutaEscribir(string extension)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMdd") + "_Download"+extension);
        }
        static void WriteLineGreen(string texto)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ForegroundColor = originalColor;
        }
        static void WriteLineRed(string texto)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ForegroundColor = originalColor;
        }
        static void WriteLineCyan(string texto)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(texto);
            Console.ForegroundColor = originalColor;
        }
    }
}
