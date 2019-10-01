using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Models
{
    public class Programa
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El nombre del programa es requerido")]
        public string nombre { get; set; }
        public carrera carrera { get; set; }
        [ForeignKey(nameof(Computadora))]
        public int ComputadoraId { get; set; }
        public Computadora Computadora { get; set; }

    }
    public enum carrera
    {
        SISTEMAS, QUIMICA, COMERCIAL, CIVIL
    }
}