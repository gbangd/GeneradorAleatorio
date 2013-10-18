using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorAleatorio
{
    public class Cuadrados: Aleatorios
    {
        #region Getter Setter
        public List<double> Numeros 
        {
            get{return this.numerosDelGenerador;}
            set{this.numerosDelGenerador = value;} 
        }
        public List<double> CeroUno 
        {
            get{return this.numerosDeCeroAUno;} 
            set{this.numerosDeCeroAUno = value;} 
        }
        #endregion
    }

}
