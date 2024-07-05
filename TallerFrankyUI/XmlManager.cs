using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public class XmlManager: IArchivos
    {
        public bool Guardar()
        {
            return true;
        }
        public List<Barco> Leer()
        {
            return new List<Barco>;
        }
    }
}
