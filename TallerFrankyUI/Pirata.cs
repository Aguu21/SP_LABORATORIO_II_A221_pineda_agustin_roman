using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Parcial.WindowsForm
{
    [Serializable]
    public class Pirata: Barco
    {
        [XmlElement("Tripulacion")]
        public override int Tripulacion
        {
            get; set;
        }

        public override void CalcularCostos()
        {
            Random rand = new Random();
            Costo = rand.Next(2000, 1200);
        }

        public Pirata() { }

        public Pirata(float costo, bool estadoReparado, string nombre, 
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
