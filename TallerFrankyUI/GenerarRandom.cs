using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    //Funcion que contiene generadores de numeros random
    public static class GenerarRandom
    {
        //Genera un double dados sus limites
        public static double DoubleAleatorio(int val1, int val2)
        {
            if (val1 > val2)
            {
                throw new ArgumentException(
                    "El primer valor debe ser el mayor");
            }
            Random rand = new Random();
            return rand.NextDouble() * (val2 - val1) + val1;
        }

        //Genera un integer dados sus limites
        public static int EnteroAleatorio(int val1, int val2)
        {
            Random rand = new Random();
            return rand.Next(val1, val2);
        }
    }
}
