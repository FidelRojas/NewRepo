using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Exepciones
{
    public class MensajeError:Exception
    {
        public MensajeError(string message) : base(message) { }
    }
}
