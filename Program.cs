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

        Calculadora calc = new Calculadora();

        string comando;
        double numero;

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

        do
        {
            Console.WriteLine("Ingrese el comando (sumar, restar, multiplicar, dividir, limpiar, historial, salir):");
            comando = Console.ReadLine();

            switch (comando)
            {
                case "sumar":
                    Console.WriteLine("Ingrese el número a sumar:");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Sumar(numero);
                    break;
                case "restar":
                    Console.WriteLine("Ingrese el número a restar:");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Restar(numero);
                    break;
                case "multiplicar":
                    Console.WriteLine("Ingrese el número a multiplicar:");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Multiplicar(numero);
                    break;
                case "dividir":
                    Console.WriteLine("Ingrese el número a dividir:");
                    numero = Convert.ToDouble(Console.ReadLine());
                    calc.Dividir(numero);
                    break;
                case "limpiar":
                    calc.Limpiar();
                    break;
                case "historial":
                    // Mostrar el historial de operaciones
                    var historial = calc.ObtenerHistorial();
                    foreach(var operacion in historial)
                    {
                        Console.WriteLine($"Resultado anterior: {operacion.ResultadoAnterior}, Nuevo valor: {operacion.NuevoValor}, Tipo de operación: {operacion.OperacionMatematica1}");
                    }
                    break;
            }

            Console.WriteLine($"Resultado: {calc.Resultado}");

        } while (comando != "salir");
    }
}
