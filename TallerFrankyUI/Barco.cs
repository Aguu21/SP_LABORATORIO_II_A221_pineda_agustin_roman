using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Parcial.WindowsForm
{
    [Serializable]
    [XmlInclude(typeof(Pirata))]
    [XmlInclude(typeof(Marina))]
    public abstract class Barco
    {
        float costo;
        bool estadoReparado;
        string nombre;
        EOperacion operacion;
        int tripulacion;

        protected float Costo
        {
            get => this.costo;
            set => this.costo = value;
        }
        protected bool EstadoReparado
        {
            get => this.estadoReparado;
            set => this.estadoReparado = value;
        }
        protected string Nombre
        {
            get => this.nombre; 
            set => this.nombre = value;
        }
        protected EOperacion Operacion
        {
            get => this.operacion; 
            set => this.operacion = value;
        }
        public abstract int Tripulacion
        {
            get; set;
        }

        public abstract void CalcularCostos();

        public Barco() { }

        public Barco(float costo, bool estadoReparado, string nombre, 
            EOperacion operacion)
        {
            this.costo = costo;
            this.estadoReparado = estadoReparado;
            this.nombre = nombre;
            this.operacion = operacion;
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"{this.costo}");
            texto.AppendLine($"{this.EstadoReparado}");
            texto.AppendLine($"{this.Nombre}");
            texto.AppendLine($"{this.Operacion}");
            texto.AppendLine($"{this.Tripulacion}");
            return texto.ToString();
        }

        public bool CompararBarcos(Barco b1, Barco b2)
        {
            if(b1.Nombre == b2.Nombre)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
