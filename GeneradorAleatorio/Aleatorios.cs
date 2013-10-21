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
        private const string archivo = "numeros_aleatorios.csv";

        public Aleatorios() 
        {
            numerosDeCeroAUno = new List<double>();
            numerosDelGenerador = new List<double>();
        }

        public virtual void guardarEnArchivo() 
        {
            if (System.IO.File.Exists(archivo))
                System.IO.File.Delete(archivo);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(archivo)) 
            {
                writer.WriteLine("Numeros del Generador; Numeros de Cero a Uno");
                for (int i = 0; i < numerosDelGenerador.Count; i++)
                    writer.WriteLine(numerosDelGenerador[i] + ";" + numerosDeCeroAUno[i]);
            }
        }

        public virtual List<List<double>> kolmogorov_smirnov() 
        {
            List<List<double>> matrizDeDatos = new List<List<double>>();
            List<double> ordenado = this.numerosDeCeroAUno;
            
            List<double> listaIN = new List<double>();
            List<double> listaRestaUno = new List<double>();
            List<double> listaRestaDos = new List<double>();

            ordenado.Sort();

            for (int i = 0; i < ordenado.Count; i++) 
            {
                listaIN.Add(Math.Round((((double)i + 1) / (double)ordenado.Count),3));
                listaRestaUno.Add(listaIN[i] - ordenado[i]);
                listaRestaDos.Add(Math.Round((ordenado[i] - ((double)i / (double)ordenado.Count)),3));
            }

            matrizDeDatos.Add(ordenado);
            matrizDeDatos.Add(listaIN);
            matrizDeDatos.Add(listaRestaUno);
            matrizDeDatos.Add(listaRestaDos);

            return matrizDeDatos;
        }

        public virtual List<List<double>> chi_cuadrado()
        {
            List<List<double>> matrizDeDatos = new List<List<double>>();
            List<double> listaO = new List<double>();
            List<double> listaFi = new List<double>();
            List<double> listaEi = new List<double>();
            List<double> listaLimite = new List<double>();

            int n = this.numerosDeCeroAUno.Count; 
            int m =(int)Math.Sqrt(n);
            double Ei = n / m;

            for (int i = 0; i < m; i++)
            {
                double inicio = (Convert.ToDouble(i) / Convert.ToDouble(m));
                double fin = (Convert.ToDouble(i+1)) / Convert.ToDouble(m);
                listaLimite.Add(fin);
                listaO.Add(cuantasEnElIntervalo(inicio,fin));
                listaEi.Add(Ei);
                listaFi.Add(Math.Round((Math.Pow((listaO[i]-Ei),2)/Ei),3));
            }

            matrizDeDatos.Add(listaLimite);
            matrizDeDatos.Add(listaO);
            matrizDeDatos.Add(listaEi);
            matrizDeDatos.Add(listaFi);

            return matrizDeDatos;
        }

        public virtual double promedio() 
        {
            double promedio = Math.Round(numerosDeCeroAUno.Average(),3);
            const double puntoCinco = (double)(0.5);
            double raizInferior = Math.Sqrt(0.083);
            double raizSuperior = Math.Sqrt(numerosDeCeroAUno.Count);
            return ((promedio-puntoCinco)*Math.Round(raizSuperior,3))/Math.Round(raizInferior,3);
        }

        private int cuantasEnElIntervalo(double inicio, double fin) 
        {
            int counter = 0;
            foreach (double i in numerosDeCeroAUno)
            {
                if (fin != 1)
                {
                    if (inicio <= i && i < fin)
                        counter++;
                }
                else 
                {
                    if (inicio <= i && i <= fin)
                        counter++;
                }

            }
            return counter;
        }
    }
}
