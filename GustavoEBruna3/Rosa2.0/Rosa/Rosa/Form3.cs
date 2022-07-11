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
    public partial class Rosa : Form
    {
        Form1 inicio1;

        public Rosa()
        {
            InitializeComponent();
           
        }

        private void usuario_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //conexao com BD
                string conexao = "server=localhost;DataBase=Rosa1;Uid=root;password=";
                var connection = new MySqlConnection(conexao);
                var comand = connection.CreateCommand();

                MySqlCommand query = new MySqlCommand("select* from Administrador where usuario ='" + textBox1.Text + "' and senha ='" + textBox2.Text + "'", connection);

                connection.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dataTable);

                foreach (DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt32(list.ItemArray[0]) > 0)
                    {
                        inicio1 = new Form1();
                        MessageBox.Show("Bem-Vindo!");
                        this.Visible = false;
                        inicio1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Senha ou usuário incorretos. Tente novamente.");
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("erro" + erro);
            }//fim do try catch
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
