using System;
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
    public partial class Cadastrar : Form
    {
        Form2 calenda;
        Ciclo cicloo;
        DAO novo;
        public Cadastrar()
        {
            InitializeComponent();
            
            cicloo = new Ciclo();
            novo = new DAO();
            CodigoBox.Text = Convert.ToString(novo.ConsultarCodigo() + 1);
           CodigoBox.ReadOnly = true;

        }// Fim do metodo de construtor
        public void Limpar()
        {
            
            CodigoBox.Text = "" + novo.ConsultarCodigo();//Código
            NomeBox.Text = "";//CPF
            MenoPausaBox.Text = "";//Nome
            MenarcaBox.Text = "";//Telefone
            DataBox.Text = "";//Telefone
            PesoBox.Text = "";//Endereço
            
        }//fim do método limpar
        public void AtivarCampos()
        {
            CodigoBox.ReadOnly = false;//Código
            NomeBox.ReadOnly = true;
            MenoPausaBox.ReadOnly = true;//CPF
            MenarcaBox.ReadOnly = true;//Nome
            DataBox.ReadOnly = true;//Telefone
            PesoBox.ReadOnly = true;//Endereço
        }//fim do ativar

        public void InativarCampos()
        {
            CodigoBox.ReadOnly = true;//Código
            NomeBox.ReadOnly = false;//Código
            MenoPausaBox.ReadOnly = false;//CPF
            MenarcaBox.ReadOnly = false;//Nome
            DataBox.ReadOnly = false;//Telefone
            PesoBox.ReadOnly = false;//Endereço
        }//fim do Inativar

        public void AtivarTodosOsCampos()
        {
            CodigoBox.ReadOnly = false;//Código
            NomeBox.ReadOnly = false;//Código
            MenoPausaBox.ReadOnly = false;//CPF
            MenarcaBox.ReadOnly = false;//Nome
            DataBox.ReadOnly = false;//Telefone
            PesoBox.ReadOnly = false;//Endereço
        }
        private void NomeBox_TextChanged(object sender, EventArgs e)
        {

        }// caixa de infomação do nome

        private void DataBox_TextChanged(object sender, EventArgs e)
        {

        }// Caixa de informação do Data de nacimento

        private void PesoBox_TextChanged(object sender, EventArgs e)
        {

        }// Caixa de informação Peso 

        private void MenarcaBox_TextChanged(object sender, EventArgs e)
        {

        }//Caixa de infomação menarca 

        private void MenoPausaBox_TextChanged(object sender, EventArgs e)
        {

        }//Caixa de informação da menopausa

        private void CodigoBox_TextChanged(object sender, EventArgs e)
        {

        }//Caixa de informação do codigo 

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                novo.PreencherVetor();
                

                //Chamar o método inserir que foi Criado na classe cadastrar

              
                string nome = (NomeBox.Text);
                string dataN = (DataBox.Text);
                string  peso = PesoBox.Text;
                string menarca = (MenarcaBox.Text);
                string menopausa = (MenoPausaBox.Text);
              
                novo.Inserir(nome,  dataN,  peso, menarca, menopausa);
                
            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
            }

        }//Fim do Cadastrar

        private void Cadastrar_Load(object sender, EventArgs e)
        {

        }

        private void ciclo_Click(object sender, EventArgs e)
        {
            calenda = new Form2();
            calenda.ShowDialog();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            AtivarTodosOsCampos();
            if (CodigoBox.Text == "")
            {
                
                NomeBox.Text = novo.ConsultarNome(Convert.ToInt32(CodigoBox.Text));
                DataBox.Text = novo.ConsultarData (Convert.ToInt32(CodigoBox.Text));
                PesoBox.Text = novo.ConsultarPeso(Convert.ToInt32(CodigoBox.Text));
                MenarcaBox.Text = novo.ConsultarMenarca(Convert.ToInt32(CodigoBox.Text));
                MenoPausaBox.Text = novo.ConsultarMenoPausa(Convert.ToInt32(CodigoBox.Text));

            }
            else
            {
              
                string Atunome = novo.Atualizar(Convert.ToInt32(CodigoBox.Text), "nome", NomeBox.Text);
                // atualizar Nome
                string  AtudataN = novo.Atualizar(Convert.ToInt32(CodigoBox.Text), "dataN", DataBox.Text);
                //atualizar telefone
                string Atupeso = novo.Atualizar(Convert.ToInt32(CodigoBox.Text), "peso", PesoBox.Text);
                //atualizar endereco
                string Atumenarca = novo.Atualizar(Convert.ToInt32(CodigoBox.Text), "menarca", MenarcaBox.Text); 
                string Atumenopausa = novo.Atualizar(Convert.ToInt32(CodigoBox.Text), "menopausa", MenoPausaBox.Text);
                //Resposta...
                
                if (( Atunome== "Atualizado!") && (AtudataN == "Atualizado!") && (Atupeso== "Atualizado!") && (Atumenarca == "Atualizado!") && (Atumenopausa == "Atualizado!"))
                {
                    MessageBox.Show("Atualizado com Sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Atualizado!");
                }
                Limpar();//Limpo os campos

            }
          
        }
       

        private void consultar_Click(object sender, EventArgs e)
        {

            if (CodigoBox.ReadOnly == true)
            {
                AtivarCampos();
            }
            else
            {
               
                NomeBox.Text = novo.ConsultarNome(Convert.ToInt32(CodigoBox.Text));//Preenchendo o campo     
                DataBox.Text = novo.ConsultarData(Convert.ToInt32(CodigoBox.Text));//Preenchendo o campo nome
                PesoBox.Text = novo.ConsultarPeso(Convert.ToInt32(CodigoBox.Text));//Prenchendo o campo telefone
                MenarcaBox.Text = novo.ConsultarMenarca(Convert.ToInt32(CodigoBox.Text)); 
                MenoPausaBox.Text = novo.ConsultarMenoPausa(Convert.ToInt32(CodigoBox.Text));
            }
        }
    }
}

