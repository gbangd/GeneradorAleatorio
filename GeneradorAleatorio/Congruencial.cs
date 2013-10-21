using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorAleatorio
{
    public class Congruencial: Aleatorios
    {

        public void generar(int a, int c, int m, double semilla, int cantidadDeNumeros)
        {
            int i =0;
            while(i < cantidadDeNumeros)
            {
                semilla = ((a*semilla)+c)%m;
                this.numerosDelGenerador.Add(semilla);
                this.numerosDeCeroAUno.Add (Math.Round((semilla /(m-1)),3));
                i++;
            }
            this.guardarEnArchivo();
        }

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
