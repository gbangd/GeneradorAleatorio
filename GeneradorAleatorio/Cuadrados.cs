using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorAleatorio
{
    public class Cuadrados: Aleatorios
    {

        public void generar(double semilla, int cantidadDeNumeros) 
        {
            while (cantidadDeNumeros > 0)
            {
                double alCuadrado = Math.Pow(semilla, 2);
                string cadenaCuadrado = Convert.ToString(alCuadrado);
                if (cadenaCuadrado.Length % 2 != 0)
                    cadenaCuadrado = "0" + cadenaCuadrado;
                if (cadenaCuadrado.Length > 4)
                    semilla = double.Parse(cadenaCuadrado.Substring((cadenaCuadrado.Length / 2) - 1, 4));
                else
                    semilla = double.Parse(cadenaCuadrado);
                this.numerosDelGenerador.Add(semilla);
                this.numerosDeCeroAUno.Add(semilla / 10000);
                cantidadDeNumeros--;
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
