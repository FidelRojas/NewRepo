using EstudianteFinal.Exepciones;
using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{
    public class ComputadorasService: IComputadorasService
    {
        private List<Computadora> computadoras;
        private HashSet<string> allowedOrderByValues;
        public ComputadorasService()
        {
            computadoras = new List<Computadora>()
            {
                new Computadora()
                {
                    id=1,
                    code="PC-1",
                },
                new Computadora()
                {
                    id=2,
                    code="PC-2"
                }
            };
            allowedOrderByValues = new HashSet<string>() { "id", "code" };

        }

        public Computadora CreateComputadora(Computadora newComputadora)
        {

            var lastComputadora = computadoras.OrderByDescending(a => a.id).FirstOrDefault();
            var nexId = lastComputadora == null ? 1 : lastComputadora.id + 1;
            newComputadora.id = nexId;
            computadoras.Add(newComputadora);
            if (newComputadora != null)
            {
                return newComputadora;

            }
            else
                throw new MensajeError("Error");


        }

        public bool DeleteComputadora(int id)
        {
            var estudianteDelete = computadoras.SingleOrDefault(a => a.id == id);
            if (estudianteDelete == null)
            {
                throw new MensajeError($"estudiante {id} no existe");
            }
            return computadoras.Remove(estudianteDelete);
        }

        public Computadora GetComputadora(int id)
        {

            var estudiante = computadoras.SingleOrDefault(a => a.id == id);

            if (estudiante == null)
            {
                throw new MensajeError($"No se encontro la compu {id}");

            }

            return estudiante;

        }

        public IEnumerable<Computadora> GetComputadoras(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new MensajeError($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }

            switch (orderByLower)
            {
                case "code":
                    return computadoras.OrderBy(a => a.code);
                
                default:
                    return computadoras.OrderBy(a => a.id); ;
            }
        }

        public Computadora UptateComputadora(int id, Computadora newComputadora)
        {
            if (computadoras.Exists(s => s.id == id))
            {
                computadoras.Find(s => s.id == id).code = newComputadora.code;
            }
            else
                throw new MensajeError("id URL should be euqual to body");

            return computadoras.Find(s => s.id == id);
        }
    }
}