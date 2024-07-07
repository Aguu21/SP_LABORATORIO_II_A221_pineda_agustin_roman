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
                                result = AccesoDatos.Guardar(
                                    p.Nombre, p.Costo);
                                break;
                            case Marina m:
                                m.CalcularCostos();
                                result  = AccesoDatos.Guardar(
                                    m.Nombre, m.Costo);
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
