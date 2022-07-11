using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Rosa
{
    class DaoLoguin
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;


        //Declarar os vetores...
        public int[] vetorCodigo;
        public string[] vetorUsuario;
        public string[] vetorSenha;


        public int i;//Declarando o contador do for e do while
        public int contador;//Utilizado para contar as voltas do while
        public string msg;
        public int contarCodigo;

        public DaoLoguin()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=Rosa1;Uid=root;password=");
            try
            {
                conexao.Open();//Tentando conectar ao BD

            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);//Enviando a mesagem de erro aos usuários
                conexao.Close();//fechando a conexão com o banco de dados
            }
        }//fim do DAOPessoa

        public void Inserir(string usuario, string senha)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + usuario + "','" + senha + "')";
                comando = "Insert into Administrador(codigo, usuario, senha ) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                if (resultado == "1")
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Cadastrado!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from Administrador";//Comando para coletar dados do banco de dados

            i = 0;//Declaração do contador 0
            contador = 0;//Declarar o contador 0 para o while
            contarCodigo = 0;//Instanciando o contador para o código

            //Instanciando os vetores...
            vetorCodigo = new int[100];
            vetorUsuario = new string[100];
            vetorSenha = new string[100];



            //Preencher os vetores criados anteriormente, ou seja, dar valores iniciais para os vetores
            for (i = 0; i < 100; i++)
            {
                vetorCodigo[i] = 0;
                vetorUsuario[i] = "";
                vetorSenha[i] = "";


            }//fim do for

            //Realizar os comandos de consulta ao Banco de Dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Ler os dados de acordo com o que está no Banco de Dados
            MySqlDataReader leitura = coletar.ExecuteReader(); //Variável leitura, faz uma consulta ao BD

            i = 0;
            contador = 0;
            //Preencher os vetores com dados do banco de dados
            while (leitura.Read())//Enquanto for verdadeiro, executa o que está no while
            {
                vetorCodigo[i] = Convert.ToInt32(leitura["codigo"]);
                vetorUsuario[i] = leitura["usuario"] + "";
                vetorSenha[i] = leitura["senha"] + "";

                contarCodigo = contador;//Armazenando a última posição do contador
                i++;//Contador sai da posição zero e vai se incrementando
                contador++;//Contar os loops do while
            }//fim do while

            leitura.Close();//Fechar a conexão e leitura do banco de dados
        }//fim do preencherVetor
    
    }
}
