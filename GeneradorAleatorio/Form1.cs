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
        Cuadrados generadorCuadrados;

        public Form1()
        {
            InitializeComponent();
            generadorCongruencial = new Congruencial();
            generadorCuadrados = new Cuadrados();
        }

        #region Eventos
        private void button1_Click(object sender, EventArgs e)
        {
            generadorCongruencial.generar(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text), int.Parse(textBox3.Text), 
                double.Parse(textBox5.Text), int.Parse(textBox4.Text));

            List<List<double>> tablaDeDatos = new List<List<double>>();
            tablaDeDatos.Add(generadorCongruencial.Numeros);
            tablaDeDatos.Add(generadorCongruencial.CeroUno);

            this.llenarTabla(tablaDeDatos, dataGridView1);
            dataGridView1.Columns[0].HeaderCell.Value = "Numeros del Generador";
            dataGridView1.Columns[1].HeaderCell.Value = "Numeros de Cero a Uno";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generadorCuadrados.generar(double.Parse(textBox6.Text), int.Parse(textBox7.Text));

            List<List<double>> tablaDeDatos = new List<List<double>>();
            tablaDeDatos.Add(generadorCuadrados.Numeros);
            tablaDeDatos.Add(generadorCuadrados.CeroUno);

            this.llenarTabla(tablaDeDatos,dataGridView2);
            dataGridView2.Columns[0].HeaderCell.Value = "Numeros del Generador";
            dataGridView2.Columns[1].HeaderCell.Value = "Numeros de Cero a Uno";
        }
        #endregion

        #region Metodos de la Vista
        public void llenarTabla(List<List<double>> matriz, DataGridView dataGrid)
        {
            int columnas = matriz.Count;
            int filas = matriz[0].Count;

            dataGrid.ColumnCount = columnas;
            dataGrid.RowCount = filas;

            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    dataGrid[i, j].Value = matriz[i][j];
                }
            }
        }
        #endregion
    }
}

