using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace online_voting_application
{
    public partial class Admin_page : Form
    {
        public Admin_page()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            USER u1 = new USER();
            u1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ELECTIONS EC = new ELECTIONS();
            EC.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome ob2 = new Welcome();
            ob2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Candidates cn = new Candidates();
            cn.Show();
        }
    }
}
