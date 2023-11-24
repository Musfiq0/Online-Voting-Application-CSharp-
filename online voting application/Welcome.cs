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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// login button
        {
            this.Hide();
            Login ob2 = new Login();
            ob2.Show();
        }

        private void button3_Click(object sender, EventArgs e)//register button
        {
            this.Hide();
            Registration ob1 = new Registration();
            ob1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contact ob4 = new Contact();
            ob4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
