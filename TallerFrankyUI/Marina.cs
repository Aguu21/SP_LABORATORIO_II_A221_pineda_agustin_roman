using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parcial.WindowsForm
{
    [Serializable]
    public class Marina: Barco
    {
        [XmlElement("Tripulacion")]
        public override int Tripulacion
        {
            get; set;
        }

        public override void CalcularCostos()
        {
            Random rand = new Random();
            Costo = rand.Next(5000, 25000);
        }

        public Marina() { }

        public Marina(float costo, bool estadoReparado, string nombre,
            EOperacion operacion, int tripulacion) :
            base(costo, estadoReparado, nombre, operacion)
        {
            this.Tripulacion = tripulacion;
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"{Tripulacion}");
            return texto.ToString();
        }
    }
}
