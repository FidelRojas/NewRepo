using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{
    public interface IProgramasService
    {
        IEnumerable<Programa> GetProgramas(string orderBy);
        Programa GetPrograma(int id);
        Programa CreatePrograma(Programa newPrograma);
        bool DeletePrograma(int id);
        Programa UptatePrograma(int id, Programa newPrograma);
        bool AsignarProgamaAComputadora(int ComputadoraId, int ProgramaId, Computadora computadora);
        bool AgregarPrograma(Programa programa);
        Programa obtenerPrograma(int id);
    }
}
