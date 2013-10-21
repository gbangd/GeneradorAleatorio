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

            //comboBox1.SelectedIndex = 0;
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

            button3.Enabled = true;
            comboBox1.Enabled = true;
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

            button4.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/numeros_aleatorios.csv");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/numeros_aleatorios.csv");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    var datos =generadorCongruencial.kolmogorov_smirnov();
                    double dMaximo = datos[2].Max();
                    double dMinimo = datos[3].Min();

                    this.llenarTabla(datos, dataGridView3);
                    dataGridView3.Columns[0].HeaderCell.Value = "F(Xi)";
                    dataGridView3.Columns[1].HeaderCell.Value = "i/n";
                    dataGridView3.Columns[2].HeaderCell.Value = "i/n - F(Xi)";
                    dataGridView3.Columns[3].HeaderCell.Value = "F(Xi) - (i-1)/n";
                    label7.Text = "KOLMOGOROV-SMIRNOV (DMAX: "+dMaximo+"; DMIN: "+dMinimo+" <--> MAXIMO: "+Math.Max(dMaximo, dMinimo)+")";;
                    dataGridView3.Focus();
                    break;
                case 1:
                    label7.Text = "PROMEDIOS\n\nZ: " + generadorCongruencial.promedio() + "\n\n\n";
                    break;
                case 2:
                    var datos2 = generadorCongruencial.chi_cuadrado();
                    double sumatoria = datos2[3].Sum();
                    this.llenarTabla(datos2, dataGridView3);
                    dataGridView3.Columns[0].HeaderCell.Value = "Intervalo";
                    dataGridView3.Columns[1].HeaderCell.Value = "Oi";
                    dataGridView3.Columns[2].HeaderCell.Value = "Ei";
                    dataGridView3.Columns[3].HeaderCell.Value = "(Oi-Ei)²/Ei";
                    label7.Text = "CHI-CUADRADA (SUMATORIA de (Oi-Ei)²/Ei: "+sumatoria+")";
                    dataGridView3.Focus();
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    var datos =generadorCuadrados.kolmogorov_smirnov();
                    double dMaximo = datos[2].Max();
                    double dMinimo = datos[3].Min();
                    
                    this.llenarTabla(datos, dataGridView4);
                    dataGridView4.Columns[0].HeaderCell.Value = "F(Xi)";
                    dataGridView4.Columns[1].HeaderCell.Value = "i/n";
                    dataGridView4.Columns[2].HeaderCell.Value = "i/n - F(Xi)";
                    dataGridView4.Columns[3].HeaderCell.Value = "F(Xi) - (i-1)/n";
                    label11.Text = "KOLMOGOROV-SMIRNOV (DMAX: "+dMaximo+"; DMIN: "+dMinimo+"  <-->  MAXIMO: "+Math.Max(dMaximo, dMinimo)+")";;
                    dataGridView4.Focus();
                    break;
                case 1:
                    label11.Text = "PROMEDIOS\n\nZ: " + generadorCuadrados.promedio() + "\n\n\n";
                    break;
                case 2:
                    var datos2 = generadorCuadrados.chi_cuadrado();
                    double sumatoria = datos2[3].Sum();
                    this.llenarTabla(datos2, dataGridView4);
                    dataGridView4.Columns[0].HeaderCell.Value = "Intervalo";
                    dataGridView4.Columns[1].HeaderCell.Value = "Oi";
                    dataGridView4.Columns[2].HeaderCell.Value = "Ei";
                    dataGridView4.Columns[3].HeaderCell.Value = "(Oi-Ei)²/Ei";
                    label11.Text = "CHI-CUADRADA (SUMATORIA de (Oi-Ei)²/Ei: " + sumatoria + ")";
                    dataGridView4.Focus();
                    break;
            }
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

