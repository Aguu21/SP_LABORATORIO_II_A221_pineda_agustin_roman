using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parcial.WindowsForm
{
    //Manejador de interacciones con archivos XML.
    public class XmlManager: IArchivos
    {
        //Guarda el objeto dado en un archivo XML.
        public bool Guardar(List<Barco> obj, string path)
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<Barco>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serial.Serialize(writer, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return false;
            }
        }

        //Lee un archivo XML y guarda su contenido en una variable.
        public List<Barco> Leer(string path)
        {
            try
            {
                List<Barco> lista = new List<Barco>();
                using (StreamReader reader = new StreamReader(path))
                {
                    XmlSerializer des = new XmlSerializer(typeof(List<Barco>));

                    lista = (List<Barco>)des.Deserialize(reader);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return new List<Barco>();
            }
           
        }
    }
}
