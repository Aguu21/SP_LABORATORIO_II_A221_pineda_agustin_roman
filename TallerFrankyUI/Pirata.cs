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
            get { return this.tripulacion; }
            set
            {
                if (value == 0)
                {
                    this.tripulacion = GenerarRandom.EnteroAleatorio(10, 30);
                }
                else
                {
                    this.tripulacion = value;
                }
            }
        }

        public override void CalcularCostos()
        {
            Costo = (float)GenerarRandom.DoubleAleatorio(2000, 12000);
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
            texto.AppendLine($" Tripulación: {Tripulacion}");
            return texto.ToString();
        }
    }
}
