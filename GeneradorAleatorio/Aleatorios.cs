using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorAleatorio
{
    public class Aleatorios
    {
        protected List<double> numerosDelGenerador;
        protected List<double> numerosDeCeroAUno;

        public Aleatorios() 
        {
            numerosDeCeroAUno = new List<double>();
            numerosDelGenerador = new List<double>();
        }
    }
}
