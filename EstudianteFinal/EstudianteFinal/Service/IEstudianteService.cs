using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> GetEstudiantes(string orderBy);
        Estudiante GetEstudiante(int id);
        Estudiante CreateEstudiante(Estudiante newEstudiante);
        bool DeleteEstudiante(int id);
        Estudiante UptateEstudiante(int id, Estudiante newEstudiante);
        Estudiante obtenerEstudiante(int id);

    }
}
