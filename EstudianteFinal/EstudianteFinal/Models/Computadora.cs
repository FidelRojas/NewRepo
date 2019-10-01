using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Models
{
    public class Computadora
    {
        public int id { get; set; }
        public string code { get; set; }
        public List<Programa> Programas { get; set; }
    }
}
