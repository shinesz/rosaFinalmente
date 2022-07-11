using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rosa
{
    public partial class cadastrologin : Form
    {
        DaoLoguin cada;
        public cadastrologin()
        {
            InitializeComponent();
            cada = new DaoLoguin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                cada.PreencherVetor();


                //Chamar o método inserir que foi Criado na classe cadastrar


                string usuario = (textBox1.Text);
                string senha = (textBox2.Text);
                
                cada.Inserir(usuario,senha);

            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
            }
        }

        private void cadastrologin_Load(object sender, EventArgs e)
        {

        }
    }
}
