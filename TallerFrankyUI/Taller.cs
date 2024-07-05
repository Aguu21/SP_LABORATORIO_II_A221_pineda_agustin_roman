using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public class Taller
    {
        List<Barco> barcos;

        public List<Barco> Barcos 
        {
            get => this.barcos;
            set => this.barcos = value;
        }

        public Taller()
        {
            Barcos = new List<Barco>();
        }

        public bool EncontrarBarco(Barco barco)
        {
            foreach(Barco b in Barcos)
            {
                if(b == barco)
                {
                    return true;
                }
            }
            return false;
        }
        public Taller IngresarBarco(Barco b)
        {
            if (!EncontrarBarco(b))
            {
                Barcos.Add(b);
            }
            return this;
        }

        public bool Reparar()
        {
            return true;
        }
    }
}
