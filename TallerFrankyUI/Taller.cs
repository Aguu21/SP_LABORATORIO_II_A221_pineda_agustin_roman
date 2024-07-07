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
    //Cuenta con una lista de Barco que pueden reparar, encontrar o ingresar.
    public class Taller
    {
        public List<Barco> Barcos { get; set; }

        public Taller()
        {
            Barcos = new List<Barco>();
        }

        //Revisa si hay barcos repetidos en el taller.
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
        
        //Agrega un Barco al taller.
        public Taller IngresarBarco(Barco b)
        {
            if (!EncontrarBarco(b))
            {
                Barcos.Add(b);
            }
            return this;
        }

        //Actualiza un Barco en el taller.
        public Taller ActualizarBarco(Barco b, string nombreViejo)
        {
            int index = Barcos.FindIndex(barco => 
            barco.Nombre == nombreViejo);
            Barcos[index] = b;
            return this;
        }

        public Taller BorrarBarco(Barco b)
        {
            Barcos.Remove(b);
            return this;
        }

        //Cambia el EstadoReparado de los barcos dado un taller y guarda un
        //mensaje en la db.
        public bool Reparar(Object t)
        {
            if (!(t is Taller taller)) return false;

            try
            {
                bool result = true;
                foreach (Barco b in taller.Barcos)
                {
                    if (!b.EstadoReparado)
                    {
                        switch(b)
                        {
                            case Pirata p:
                                p.CalcularCostos();
                                result = AccesoDatos.Guardar($"Se reparó " +
                                    $"el {p.Nombre} a un costo de {p.Costo}" +
                                    $" berries");
                                break;
                            case Marina m:
                                m.CalcularCostos();
                                result = AccesoDatos.Guardar($"Se reparó " +
                                    $"el {m.Nombre} a un costo de {m.Costo}" +
                                    $" berries"); 
                                break;
                        }

                        if (!result) { return false; }
                        b.EstadoReparado = true;
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
