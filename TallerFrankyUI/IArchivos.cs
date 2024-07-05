using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public interface IArchivos
    {
        bool Guardar();
        List<Barco> Leer();
    }
}
