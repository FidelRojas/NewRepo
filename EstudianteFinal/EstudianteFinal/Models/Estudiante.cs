﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        public string name { get; set; }
        public carrera carrera { get; set; }
    }
}
