using EspacioProgram;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int cantidad;
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        IGestionTareas gestionTareas = new Tarea();

        Console.Write($"¿Cuántas tareas desea crear?: ");
        cantidad = int.Parse(Console.ReadLine());
        
        tareasPendientes = Tarea.CrearTareas(cantidad);

        string opcion;
        do
        {
            Console.WriteLine("¿Desea mover una tarea a la lista de realizadas? (s/n)");
            opcion = Console.ReadLine();
            if (opcion.ToLower() == "s")
            {
                Console.Write("Ingrese el ID de la tarea a mover: ");
                int idTarea = int.Parse(Console.ReadLine());
                gestionTareas.MoverTarea(tareasPendientes, tareasRealizadas, idTarea);
            }

            Console.WriteLine("¿Desea buscar una tarea por descripción? (s/n)");
            opcion = Console.ReadLine();
            if (opcion.ToLower() == "s")
            {
                Console.Write("Ingrese la descripción de la tarea a buscar: ");
                string descripcion = Console.ReadLine();
                var tareasEncontradas = gestionTareas.BuscarTareasPendientesPorDescripcion(tareasPendientes, descripcion);
                foreach (var tarea in tareasEncontradas)
                {
                    Console.WriteLine($"ID: {tarea.Id}, Descripción: {tarea.Descripcion}, Duración: {tarea.Duracion}");
                }
            }

            Console.WriteLine("¿Desea realizar otra operación? (s/n)");
            opcion = Console.ReadLine();
        } while (opcion.ToLower() == "s");
    }
}
