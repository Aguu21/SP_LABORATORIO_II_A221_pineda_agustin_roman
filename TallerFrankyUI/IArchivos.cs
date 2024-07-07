using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    //Interfaz para el manejo de archivos.
    public interface IArchivos
    {
        bool Guardar(List<Barco> obj, string path);
        List<Barco> Leer(string path);
    }
}
