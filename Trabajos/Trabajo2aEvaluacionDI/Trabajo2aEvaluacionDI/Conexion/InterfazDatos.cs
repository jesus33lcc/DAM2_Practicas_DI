using System.Collections.Generic;

namespace Trabajo2aEvaluacionDI.Conexion
{
    /// <summary>
    /// Interfaz genérica para operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en una fuente de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de datos con el que opera la interfaz.</typeparam>
    public interface InterfazDatos<T>
    {
        /// <summary>
        /// Obtiene todos los elementos.
        /// </summary>
        /// <returns>Lista de elementos del tipo especificado.</returns>
        List<T> GetAll();
        /// <summary>
        /// Inserta un nuevo elemento.
        /// </summary>
        /// <param name="data">Elemento a insertar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        bool Insert(T data);
        /// <summary>
        /// Actualiza un elemento existente.
        /// </summary>
        /// <param name="data">Elemento a actualizar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        bool Update(T data);
        /// <summary>
        /// Elimina un elemento.
        /// </summary>
        /// <param name="data">Elemento a eliminar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        bool Delete(T data);
    }
}
