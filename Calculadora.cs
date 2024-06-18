using System;
using System.Collections.Generic;

namespace EspacioProgram
{
    public class Calculadora
    {
        private double dato;
        private List<Operacion> historialOperaciones;
        
        public Calculadora()
        {
            dato = 0;
            historialOperaciones = new List<Operacion>(); 
        }
        public void Sumar(double termino)
        {
            dato += termino;
            historialOperaciones.Add(new Operacion(dato, termino, TipoOperacion.Sumar));
        }

        public void Restar(double termino)
        {
            dato -= termino;
            historialOperaciones.Add(new Operacion(dato, termino, TipoOperacion.Restar));
        }

        public void Multiplicar(double termino)
        {
            dato *= termino;
            historialOperaciones.Add(new Operacion(dato, termino, TipoOperacion.Multiplicar));
        }

        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                dato /= termino;
                historialOperaciones.Add(new Operacion(dato, termino, TipoOperacion.Dividir));
            }
            else
            {
                Console.WriteLine("Error: División por cero.");
            }
        }

        public void Limpiar()
        {
            dato = 0;
        }
        public double Resultado
        {
            get { return dato; }
        }

        public List<Operacion> ObtenerHistorial()
        {
            return historialOperaciones;
        }
    }
}
