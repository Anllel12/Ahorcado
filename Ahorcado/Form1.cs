using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        String palabraOculta = "";

        int numeroFallos = 0;

        Boolean acierto = false;



        ArrayList botonesPulsados = new ArrayList();//almaceno todos los botones pulsados

        public Form1()
        {
            InitializeComponent();
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            Button boton = (Button)sender;//casteo el objeto a boton. Solo va a poder ser boton porque solo se genera en los botones

            botonesPulsados.Add(boton);//lo añado al arrayList para más adelante

            String letra = boton.Text;
           
            if (numeroFallos <= palabraOculta.Length)
            {
                if (palabraOculta.Contains(letra))
                {
                    int posicion = palabraOculta.IndexOf(letra);
                    label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);
                }

                else
                {
                    numeroFallos++;
                    boton.Visible = false;//quito el boton
                }
            }

            else
            {
                botonReinicio.Visible = true;
            }
                       
            if (!label1.Text.Contains("_"))
            {
                pictureBox1.Image = Properties.Resources.acertastetodo;

                acierto = true;

                botonReinicio.Visible = true;
            }

            if (!acierto)//voy cambiando la imagen segun los fallos
            {
                switch (numeroFallos)
                {
                    case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                    case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                    case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                    case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                    case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                    case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                    default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                }
            }
        }

        private void reinicio(object sender, EventArgs e)//reinicio el juego
        {
            if (!acierto)//si no han acertado la palabra les dejo seguir averiguandola pero con los botones que han quitado anteriormente 
            {
                numeroFallos = 0;

                botonReinicio.Visible = false;

                label1.Text = "";

                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    label1.Text = label1.Text + "_ ";
                }

                pictureBox1.Image = Properties.Resources.ahorcado_0;
            }

            else//si la han averiguado reiniciamos 
            {
                numeroFallos = 0;

                acierto = false;
                botonReinicio.Visible = false;

                label1.Text = "";

                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    label1.Text = label1.Text + "_ ";
                }

                pictureBox1.Image = Properties.Resources.ahorcado_0;

                foreach (Button boton in botonesPulsados)//vuelvo visibles todos los botones pulsados
                {
                    boton.Visible = true;
                }

                botonesPulsados.Clear();//dejo vacio el ArrayList

                
            }
        }

        private void texto(object sender, EventArgs e)
        {
            label2.Text = palabraOculta;

            for (int i = 0; i < palabraOculta.Length; i++)//pone "_ " segun el tamaño de la palabra
            {
                label1.Text = label1.Text + "_ ";
            }
        }
    }
}