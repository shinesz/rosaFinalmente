﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Rosa
{

    public partial class Form1 : Form
    {
        Form2 calenda;
        Ciclo cicloo;
        Cadastrar cadastro;

        public Form1()
        {
            InitializeComponent();
            
            

        }//fim do contrutor

        private void cadastrar_Click(object sender, EventArgs e)
        {
            cadastro = new Cadastrar();
            this.Visible = false;
            cadastro.ShowDialog();
        }//Fim do botão Cadastrar

        private void ciclo_Click(object sender, EventArgs e)
        {
            calenda = new Form2();
            this.Visible = false;
            calenda.ShowDialog();
        }// Fim do Botão Ciclo

        private void consultar_Click(object sender, EventArgs e)
        {

        }// Fim do Botão Consultar

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }//Fim da Class
}//Fim do Programa
       

