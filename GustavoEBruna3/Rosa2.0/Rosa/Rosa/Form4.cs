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
    public partial class inicio : Form
    {
        Rosa entre;
        cadastrologin cada;
        public inicio()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            entre = new Rosa();
            this.Visible = false;
            entre.ShowDialog();
            
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            cada = new cadastrologin();
            cada.ShowDialog();
        }
    }
}
