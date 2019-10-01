using EstudianteFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Service
{
    public interface IComputadorasService
    {
        IEnumerable<Computadora> GetComputadoras(string orderBy);
        Computadora GetComputadora(int id);
        Computadora CreateComputadora(Computadora newComputadora);
        bool DeleteComputadora(int id);
        Computadora UptateComputadora(int id, Computadora newComputadora);
    }
}
