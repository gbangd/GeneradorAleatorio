using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorAleatorio
{
    public partial class Form1 : Form
    {
        Congruencial generadorCongruencial;

        public Form1()
        {
            InitializeComponent();
            generadorCongruencial = new Congruencial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generadorCongruencial.generar(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text), int.Parse(textBox3.Text), 
                double.Parse(textBox5.Text), int.Parse(textBox4.Text));

            List<List<double>> tablaDeDatos = new List<List<double>>();
            tablaDeDatos.Add(generadorCongruencial.Numeros);
            tablaDeDatos.Add(generadorCongruencial.CeroUno);

            this.llenarTabla(tablaDeDatos);
            dataGridView1.Columns[0].HeaderCell.Value = "Numeros del Generador";
            dataGridView1.Columns[1].HeaderCell.Value = "Numeros de Cero a Uno";
        }

        public void llenarTabla(List<List<double>> matriz) 
        {
            int columnas = matriz.Count;
            int filas = matriz[0].Count;

            dataGridView1.ColumnCount = columnas;
            dataGridView1.RowCount = filas;

            for (int i = 0; i < columnas; i++) 
            {
                for (int j = 0; j < filas; j++) 
                {
                    dataGridView1[i, j].Value = matriz[i][j];
                }    
            }
        }
    }
}

