using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redes_Neurais
{
    public partial class Form1 : Form
    {

        double[,] Fontes = new double[21, 64] { 
        {-1,-1,1,1,-1,-1,  -1, -1, -1, -1, 1, -1, -1, -1, -1, -1, -1, 1, -1, -1, -1, -1, -1, 1, -1, 1, -1, -1, -1, -1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, -1, 1, -1, -1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1, 1, 1, 1, 1}, // A FONTE 1
        {1,1,1,1,1,1,-1,  -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,1,1,1,1,-1,-1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1,1,1,1,1,1,1,-1,1 }, // B FONTE 1
        {-1,-1,1,1,1,1,1,  -1,1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, -1,1,-1,-1,-1,-1,1, -1,-1,1,1,1,1,-1,1 }, // C FONTE 1
        {1,1,1,1,1,-1,-1,  -1,1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,1,-1, 1,1,1,1,1,-1,-1,1 }, // D FONTE 1
        {1,1,1,1,1,1,1,  -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,-1, -1,1,-1,1,-1,-1,-1,-1,1,1,1,-1,-1,-1, -1,1,-1,1,-1,-1,-1, -1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,1, 1,1,1,1,1,1,1,1 }, // E FONTE 1
        {-1,-1,-1,1,1,1,1,  -1,-1,-1,-1,-1,1,-1, -1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1, -1,-1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,1,-1,-1,-1,1,1,1,-1,-1,1 }, // J FONTE 1
        {1,1,1,-1,-1,1,1,  -1,1,-1,-1,1,-1,-1,-1,1,-1,1,-1,-1,-1,-1,1,1,-1,-1,-1,-1, -1,1,1,-1,-1,-1,-1, -1,1,-1,1,-1,-1,-1, -1,1,-1,-1,1,-1,-1, -1,1,-1,-1,-1,1,-1, 1,1,1,-1,-1,1,1,1 }, // K FONTE 1
        {-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,1,-1,1,-1,-1,-1,-1,1,-1,1,-1,-1,-1,1,-1,-1,-1,1,-1,-1,1,1,1,1,1,-1,-1,1,-1,-1,-1,1,-1,-1,1,-1,-1,-1,1,-1,1 }, // A FONTE 1
        {1,1,1,1,1,1,-1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,1,1,1,1,1,-1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,1,1,1,1,1,-1,1 }, // B FONTE 2
        {-1,-1,1,1,1,-1,-1, -1,1,-1,-1,-1,1,-1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,1,-1,-1,-1,1,1,1,-1,-1,1 }, // C FONTE 2
        {1,1,1,1,1,-1,-1, 1,-1,-1,-1,-1,1,-1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,1,-1, 1,1,1,1,1,-1,-1,1 }, // D FONTE 2
        {1,1,1,1,1,1,1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,1,1,1,1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,1,1,1,1,1,1,1 }, // E FONTE 2
        {-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,1,-1,-1,-1,1,1,1,-1,-1,1 }, // J FONTE 2
        {1,-1,-1,-1,-1,1,-1, 1,-1,-1,-1,1,-1,-1, 1,-1,-1,1,-1,-1,-1, 1,-1,1,-1,-1,-1,-1, 1,1,-1,-1,-1,-1,-1, 1,-1,1,-1,-1,-1,-1, 1,-1,-1,1,-1,-1,-1, 1,-1,-1,-1,1,-1,-1, 1,-1,-1,-1,-1,1,-1,1 }, // K FONTE 2
        {-1, -1, -1, 1, -1, -1, -1,  -1, -1, -1, 1, -1, -1, -1,  -1, -1, 1, -1, 1, -1, -1,  -1, -1, 1, -1, 1, -1, -1,  -1, 1, -1, -1, -1, 1, -1,  -1, 1, 1, 1, 1, 1, -1,  1, -1, -1, -1, -1, -1, 1,  1, -1, -1, -1, -1, -1, 1,1, 1, -1, -1, -1, 1, 1, 1}, // A FONTE 3
        {1,1,1,1,1,1,-1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,1,1,1,1,-1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, 1,1,1,1,1,1,-1,1 }, // B FONTE 3
        {-1,-1,1,1,1,-1,1,  -1,1,-1,-1,-1,1,1, 1,-1,-1,-1,-1,-1,1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,1,-1,1,-1,-1,-1,1,-1,-1,-1,1,1,1,-1,-1,1 }, // C FONTE 3
        {1,1,1,1,1,-1,-1,-1,1,-1,-1,-1,1,-1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,-1,1,-1,1,-1,-1,-1,-1,1, -1,1,-1,-1,-1,1,-1, 1,1,1,1,1,-1,-1, 1 }, // D FONTE 3
        {1,1,1,1,1,1,1,  -1,1,-1,-1,-1,-1,1, -1,1,-1,-1,1,-1,-1,-1,1,1,1,1,-1,-1,-1,1,-1,-1,1,-1,-1, -1,1,-1,-1,-1,-1,-1, -1,1,-1,-1,-1,-1,-1, -1,1,-1,-1,-1,-1,1,1,1,1,1,1,1,1,1 }, // E FONTE 3
        {-1,-1,-1,-1,1,1,1, -1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1,1,-1,-1,1,-1,-1,-1,1,-1,-1,-1,1,1,1,-1,-1,1 }, // J FONTE 3
        {1, 1, 1, -1, -1, 1, 1, -1, 1, -1, -1, -1, 1, -1, -1, 1, -1, -1, 1, -1, -1, -1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1, -1, -1, -1, -1, 1, -1, 1, -1, -1, -1, -1, 1, -1, -1, 1, -1, -1, -1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1, -1, 1, 1, 1}, // K FONTE 3
        };

        double[,] Saidas_Desejadas = new double[,] { {1,-1,-1,-1,-1,-1,-1,  1,-1,-1,-1,-1,-1,-1,  1,-1,-1,-1,-1,-1,-1}, // A  
                                                     {-1,1,-1,-1,-1,-1,-1,  -1,1,-1,-1,-1,-1,-1,  -1,1,-1,-1,-1,-1,-1}, // B
                                                     {-1,-1,1,-1,-1,-1,-1,  -1,-1,1,-1,-1,-1,-1,  -1,-1,1,-1,-1,-1,-1}, // C 
                                                     {-1,-1,-1,1,-1,-1,-1,  -1,-1,-1,1,-1,-1,-1,  -1,-1,-1,1,-1,-1,-1}, // D  
                                                     {-1,-1,-1,-1,1,-1,-1,  -1,-1,-1,-1,1,-1,-1,  -1,-1,-1,-1,1,-1,-1}, // E  
                                                     {-1,-1,-1,-1,-1,1,-1,  -1,-1,-1,-1,-1,1,-1,  -1,-1,-1,-1,-1,1,-1}, // J  
                                                     {-1,-1,-1,-1,-1,-1,1,  -1,-1,-1,-1,-1,-1,1,  -1,-1,-1,-1,-1,-1,1}  // K  
        };

        double[,] Pesos = new double[7, 64];
        double TaxaAprendizagem = 0.002;
        int QuantidadeMaximaCiclos = 1000;
        double ErroMinimo = 0.0001;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 9; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].HeaderCell.Value= (i + 1).ToString();
            }

            for(int Linha = 0; Linha < 9; Linha++)
            {
                for(int Coluna = 0; Coluna < 7; Coluna++)
                {
                    dataGridView2.Rows[Linha].Cells[Coluna].Value = ".";
                }
            }

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Fonte 1"); // índice 0
            comboBox1.Items.Add("Fonte 2"); // índice 1
            comboBox1.Items.Add("Fonte 3"); // índice 2

            comboBox2.Items.Clear();
            comboBox2.Items.Add("A"); // índice 0
            comboBox2.Items.Add("B"); // índice 1
            comboBox2.Items.Add("C"); // índice 2
            comboBox2.Items.Add("D"); // índice 3
            comboBox2.Items.Add("E"); // índice 4
            comboBox2.Items.Add("J"); // índice 5
            comboBox2.Items.Add("K"); // índice 6

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            chart1.Series[0].Points.Add(0, 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FONTE
            MostrarLetra();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LETRA
            MostrarLetra();
        }

        void MostrarLetra()
        {
            int Fonte = comboBox1.SelectedIndex;
            int Letra = comboBox2.SelectedIndex;

            if (Fonte == 0)
            {
                if(Letra == 0)
                PreencherGrid(0);

                if(Letra == 1)
                PreencherGrid(1);

                 if(Letra == 2)
                PreencherGrid(2);

                if(Letra == 3)
                PreencherGrid(3);

                if(Letra == 4)
                PreencherGrid(4);

                if(Letra == 5)
                PreencherGrid(5);

                if(Letra == 6)
                PreencherGrid(6);
            }


            if (Fonte == 1)
            {
                if(Letra == 0)
                PreencherGrid(7);

                if(Letra == 1)
                PreencherGrid(8);

                if(Letra == 2)
                PreencherGrid(9);

                if(Letra == 3)
                PreencherGrid(10);

                if(Letra == 4)
                PreencherGrid(11);

                if(Letra == 5)
                PreencherGrid(12);

                if(Letra == 6)
                PreencherGrid(13);
            }

            if (Fonte == 2)
            {
                if(Letra == 0)
                PreencherGrid(14);

                if(Letra == 1)
                PreencherGrid(15);

                if(Letra == 2)
                PreencherGrid(16);

                if(Letra == 3)
                PreencherGrid(17);

                if(Letra == 4)
                PreencherGrid(18);

                if(Letra == 5)
                PreencherGrid(19);

                if(Letra == 6)
                PreencherGrid(20);

            }
        }

        void PreencherGrid(int index)
        {
            int Linha, Coluna;
            Linha = 0;
            Coluna = 0;

            for (int i = 0; i < 63; i++)
            {
                if (Fontes[index, i] == 1)
                {
                    dataGridView1.Rows[Linha].Cells[Coluna].Value = "#";
                }
                else
                {
                    dataGridView1.Rows[Linha].Cells[Coluna].Value = ".";
                }

                Coluna++;
                if (Coluna == 7)
                {
                    Coluna = 0;
                    Linha++;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //TREINAR

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    Pesos[i, j] = 0;
                }
            }

            chart1.Series[0].Points.Clear();

            double ErroQuadraticoMedio = 1;
            double SomaErroQuadraticoCiclo = 0;
            double ErroQuadraticoMedioAtual = 0;
            double ErroQuadraticoMedioAnterior = 1;
            int Ciclos = 0;

            double Erro = 0;

            while((Math.Abs(ErroQuadraticoMedioAtual - ErroQuadraticoMedioAnterior) > ErroMinimo) && (Ciclos < QuantidadeMaximaCiclos))
            {
                SomaErroQuadraticoCiclo = 0;
                ErroQuadraticoMedioAnterior = ErroQuadraticoMedioAtual;

                for(int AmostraTreinamento = 0; AmostraTreinamento < 21; AmostraTreinamento++)
                {
                    for(int NeuronioSaida = 0; NeuronioSaida < 7; NeuronioSaida++)
                    {
                        double sinapse = 0;

                        for(int j = 0; j < 64; j++)
                        {
                            sinapse = sinapse + (Fontes[AmostraTreinamento, j] * Pesos[NeuronioSaida, j]);
                        }

                        Erro = Saidas_Desejadas[NeuronioSaida, AmostraTreinamento] - sinapse;

                        for( int j = 0;j < 64; j++)
                        {
                            double deltaW = Fontes[AmostraTreinamento, j] * Erro * TaxaAprendizagem;
                            Pesos[NeuronioSaida, j] = Pesos[NeuronioSaida, j] + deltaW;
                        }

                        SomaErroQuadraticoCiclo = SomaErroQuadraticoCiclo + Math.Pow(Erro, 2);
                    }
                }

                ErroQuadraticoMedio = SomaErroQuadraticoCiclo / 21;

                ErroQuadraticoMedioAtual = ErroQuadraticoMedio;

                Ciclos++;

                chart1.Series[0].Points.Add(Math.Abs(ErroQuadraticoMedio));
            }

            label4.Text = Ciclos.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] VetorParaSerTestado = new int[64];
            int PosicaoAtual = 0;
            double Resultado;
            int Y;
            string[] Letras = new string[] { "A", "B", "C", "D", "E", "J", "K" };

            label6.Text = "";

            for(int Linha = 0; Linha < 9; Linha++)
            {
                for(int Coluna = 0; Coluna < 7; Coluna++)
                {
                    string entrada = dataGridView2.Rows[Linha].Cells[Coluna].Value.ToString();
                    if (entrada == "#")
                    {
                        VetorParaSerTestado[PosicaoAtual] = 1;
                    }
                    else if (entrada == ".")
                    {
                        VetorParaSerTestado[PosicaoAtual] = -1;
                    }
                    else
                    {
                        VetorParaSerTestado[PosicaoAtual] = 0;
                    }
                       

                    PosicaoAtual += 1;
                }

            }

            VetorParaSerTestado[63] = 1;

            for(int NeuronioSaida = 0; NeuronioSaida < 7; NeuronioSaida++)
            {
                Resultado = 0;
                for(int i = 0; i < 64; i++)
                {
                    Resultado = Resultado + (VetorParaSerTestado[i] * Pesos[NeuronioSaida, i]);
                }

                if (Resultado >= 0)
                    label6.Text = label6.Text + " " + Letras[NeuronioSaida];
            }

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Quantidade de Ciclos
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Resposta da Rede
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
