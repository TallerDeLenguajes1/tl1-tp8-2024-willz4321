using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioProgram
{
    public interface IGestionTareas
    {
        void MoverTarea(List<Tarea> listaOrigen, List<Tarea> listaDestino, int tareaId);
        List<Tarea> BuscarTareasPendientesPorDescripcion(List<Tarea> listaTareas, string descripcion);
    }
}
