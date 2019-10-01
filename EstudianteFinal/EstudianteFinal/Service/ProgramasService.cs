using EstudianteFinal.Exepciones;
using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{

    public class ProgramasService : IProgramasService
    {
        public List<Programa> programas;
        private HashSet<string> allowedOrderByValues;

        public ProgramasService()
        {

            programas = new List<Programa>()
            {
                new Programa()
                {
                    id=1,
                    carrera=carrera.CIVIL
                },
                new Programa()
                {
                    id=2,
                    carrera =carrera.COMERCIAL

                }
            };
            allowedOrderByValues = new HashSet<string>() { "id", "carrera" };

        }
    
        public bool AgregarPrograma(Programa programa)
        {
            var cantidad = programas.Count;
            programa.id = cantidad + 1;
            programas.Add(programa);
            return true;
        }

        public bool AsignarProgamaAComputadora(int ComputadoraId, int ProgramaId, Computadora computadora)
        {
            if (computadora == null)
            {
                return false;
            }
            Programa programa = obtenerPrograma(ProgramaId);
            if (programa == null)
            {
                return false;
            }
            programa.ComputadoraId = computadora.id;
            return true;
        }


        public Programa CreatePrograma(Programa newPrograma)
        {

            var lastPrograma = programas.OrderByDescending(a => a.id).FirstOrDefault();
            var nexId = lastPrograma == null ? 1 : lastPrograma.id + 1;
            newPrograma.id = nexId;
            programas.Add(newPrograma);
            if (newPrograma != null)
            {
                return newPrograma;

            }
            else
                throw new MensajeError("Error");


        }

        public bool DeletePrograma(int id)
        {
            var estudianteDelete = programas.SingleOrDefault(a => a.id == id);
            if (estudianteDelete == null)
            {
                throw new MensajeError($"estudiante {id} no existe");
            }
            return programas.Remove(estudianteDelete);
        }

        public Programa GetPrograma(int id)
        {

            var estudiante = programas.SingleOrDefault(a => a.id == id);

            if (estudiante == null)
            {
                throw new MensajeError($"No se encontro la compu {id}");

            }

            return estudiante;

        }

        public IEnumerable<Programa> GetProgramas(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower)) 
            {
                throw new MensajeError($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }

            switch (orderByLower)
            {
                case "code":
                    return programas.OrderBy(a => a.carrera);

                default:
                    return programas.OrderBy(a => a.id); ;
        }                }


        public Programa UptatePrograma(int id, Programa newPrograma)
        {
            if (programas.Exists(s => s.id == id))
            {
                programas.Find(s => s.id == id).carrera = newPrograma.carrera;
            }
            else
                throw new MensajeError("id URL should be euqual to body");

            return programas.Find(s => s.id == id);
        }

        public Programa obtenerPrograma(int id)
        {
            return programas.SingleOrDefault(x => x.id == id);

        }
    }
    
}
