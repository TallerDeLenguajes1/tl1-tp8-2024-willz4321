using System;

namespace EspacioProgram
{
    public class Operacion
    {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion OperacionMatematica;

        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacionMatematica)
        {
            this.ResultadoAnterior = resultadoAnterior;
            this.NuevoValor = nuevoValor;
            OperacionMatematica1 = operacionMatematica;
        }

        public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
        public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
        public TipoOperacion OperacionMatematica1 { get => OperacionMatematica; set => OperacionMatematica = value; }
    }
}    