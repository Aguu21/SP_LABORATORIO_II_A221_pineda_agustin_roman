using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public interface IArchivos
    {
        bool Guardar(Object obj, string path);
        List<Barco> Leer(string path);
    }
}
