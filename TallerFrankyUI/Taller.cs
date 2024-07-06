using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Parcial.WindowsForm
{
    public class Taller
    {
        public List<Barco> Barcos { get; set; }

        public Taller()
        {
            Barcos = new List<Barco>();
        }


        public bool EncontrarBarco(Barco barco)
        {
            foreach(Barco b in Barcos)
            {
                if (b.CompararBarcos(barco))
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

        public bool Reparar(Object t)
        {
            try
            {
                if (t is Taller taller)
                {
                    foreach (Barco b in taller.Barcos)
                    {
                        if (!b.EstadoReparado)
                        {
                            if(b is Pirata p)
                            {
                                p.CalcularCostos();
                                AccesoDatos.Guardar(p.Nombre,(int)p.Costo);
                            }
                            else if(b is Marina m)
                            {
                                m.CalcularCostos();
                                //Agregar a la db
                            }
                            b.EstadoReparado = true;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
                return false;
            }
        }
    }
}
