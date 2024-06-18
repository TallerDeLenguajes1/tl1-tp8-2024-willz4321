using System;
using System.Collections.Generic;
using System.Linq;
using EspacioProgram;

public class Tarea : IGestionTareas
    {
        int id;
        string descripcion;
        int duracion;

        public Tarea(int id, string descripcion, int duracion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Duracion = duracion;
        }
               public Tarea()
        {
   
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public static List<Tarea> CrearTareas(int N)
        {
            List<Tarea> listaDeTareas = new List<Tarea>();
            for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"Introduce los datos para la tarea {i + 1}:");
                    // El ID se define automáticamente como la posición en la lista más uno.
                    int id = i + 1;
                    Console.Write("Descripción: ");
                    // Cambio de 'char' a 'string' para permitir una cadena de caracteres.
                    string descripcion = Console.ReadLine();
                    Console.Write("Duración en minutos: ");
                    int duracion;
                    // Asegurarse de que se ingrese un número entero para la duración.
                    while (!int.TryParse(Console.ReadLine(), out duracion))
                    {
                        Console.WriteLine("Por favor, ingresa un número entero para la duración.");
                        Console.Write("Duración en minutos: ");
                    }

                    Tarea nuevaTarea = new Tarea(id, descripcion, duracion);
                    listaDeTareas.Add(nuevaTarea);
                }
            return listaDeTareas;
        }

        public void MoverTarea(List<Tarea> listaOrigen, List<Tarea> listaDestino, int tareaId)
        {
            var tarea = listaOrigen.FirstOrDefault(t => t.Id == tareaId);
            if (tarea != null)
            {
                listaOrigen.Remove(tarea);
                listaDestino.Add(tarea);
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con ID {tareaId}.");
            }
        }

        public List<Tarea> BuscarTareasPendientesPorDescripcion(List<Tarea> listaTareas, string descripcion)
        {
            return listaTareas.Where(t => t.Descripcion == descripcion).ToList();
        }
    }