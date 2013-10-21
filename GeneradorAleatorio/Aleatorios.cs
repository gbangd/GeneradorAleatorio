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


    }
}
