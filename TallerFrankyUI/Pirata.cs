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
    //Un tipo de Barco.
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

        //Genera un valor para Costo aleatorio.
        public override void CalcularCostos()
        {
            Costo = (float)GenerarRandom.DoubleAleatorio(2000, 12000);
        }

        //Constructor vacio para serializar.
        public Pirata() { }

        public Pirata(float costo, bool estadoReparado, string nombre, 
            EOperacion operacion, int tripulacion) : 
            base(costo, estadoReparado, nombre, operacion)
        {
            this.tripulacion = tripulacion;
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
