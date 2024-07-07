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
    //Clase abstracta que abarca las caracteristicas de un barco.
    public abstract class Barco
    {
        protected float costo;
        protected bool estadoReparado;
        protected string nombre;
        protected EOperacion operacion;
        protected int tripulacion;

        [XmlElement("Costo")]
        public float Costo
        {
            get => this.costo;
            set => this.costo = value;
        }
        [XmlElement("EstadoReparado")]
        public bool EstadoReparado
        {
            get => this.estadoReparado;
            set => this.estadoReparado = value;
        }
        [XmlElement("Nombre")]
        public string Nombre
        {
            get => this.nombre; 
            set => this.nombre = value;
        }
        [XmlElement("Operacion")]
        public EOperacion Operacion
        {
            get => this.operacion; 
            set => this.operacion = value;
        }
        [XmlElement("Tripulacion")]
        public abstract int Tripulacion { get; set; }

        public abstract void CalcularCostos();

        //Constructor vacio para serializar.
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
            texto.AppendLine($" Nombre: {this.Nombre} |");
            texto.AppendLine($" Operacion: {this.Operacion} |");
            texto.AppendLine($" Estado_Reparado: {this.EstadoReparado} |");
            return texto.ToString();
        }

        //Compara barcos por nombre.
        public bool CompararBarcos(Barco barco)
        {
            return this.Nombre == barco.Nombre;
        }

    }
}
