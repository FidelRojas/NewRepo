using EstudianteFinal.Exepciones;
using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{
    public class EstudianteService : IEstudianteService
    {
        private List<Estudiante> estudiantes;
        private HashSet<string> allowedOrderByValues;
        public EstudianteService()
        {
            estudiantes = new List<Estudiante>()
            {
                new Estudiante()
                {
                    id=1,
                    name="Fidel",
                    career = "IngSistemas"
                },
                new Estudiante()
                {
                    id=2,
                    name ="Victor",
                    career="IngComercial"
                },
                new Estudiante()
                {
                    id=3,
                    name="Pinto",
                    career = "IngSistemas"
                }
            };
            allowedOrderByValues = new HashSet<string>() { "id", "name", "career" };

        }

        public Estudiante CreateEstudiante(Estudiante newEstudiante)
        {
            
            var lastEstudiante = estudiantes.OrderByDescending(a => a.id).FirstOrDefault();
            var nexId = lastEstudiante == null ? 1 : lastEstudiante.id + 1;
            newEstudiante.id = nexId;
            estudiantes.Add(newEstudiante);
            if (newEstudiante != null)
            {
                return newEstudiante;

            }
            else
                throw new MensajeError("Error");


        }

        public bool DeleteEstudiante(int id)
        {
            var estudianteDelete = estudiantes.SingleOrDefault(a => a.id == id);
            if (estudianteDelete == null)
            {
                throw new MensajeError($"estudiante {id} does not exists");
            }
            return estudiantes.Remove(estudianteDelete);
        }

        public Estudiante GetEstudiante(int id)
        {
            
            var estudiante = estudiantes.SingleOrDefault(a => a.id == id);
            
            if (estudiante == null)
            {
                throw new MensajeError($"cannot found student with id {id}");

            }

            return estudiante;

        }

        public IEnumerable<Estudiante> GetEstudiantes(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new MensajeError($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }

            switch (orderByLower)
            {
                case "name":
                    return estudiantes.OrderBy(a => a.name);
                case "career":
                    return estudiantes.OrderBy(a => a.career);

                default:
                    return estudiantes.OrderBy(a => a.id); ;
            }
        }

        public Estudiante UptateEstudiante(int id, Estudiante newEstudiante)
        {
            if (estudiantes.Exists(s => s.id == id))
            {
                estudiantes.Find(s => s.id == id).name = newEstudiante.name;
                estudiantes.Find(s => s.id == id).career = newEstudiante.career;
            }
            else
                throw new MensajeError("id URL should be euqual to body");
            return estudiantes.Find(s => s.id == id);
        }
    }
}
