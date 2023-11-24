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
    public partial class User_Page : Form
    {
        public User_Page()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            Welcome ob2 = new Welcome();
            ob2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vote_Candidate v1 = new Vote_Candidate();
            v1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Apply A1 = new Apply();
            A1.Show();
        }
    }
}
