using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace online_voting_application
{
    public partial class Candidates : Form
    {
        public Candidates()
        {
            InitializeComponent();
        }

        private void Candidates_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
            con.Open();
            SqlDataAdapter sdal = new SqlDataAdapter("Select * from Candidates", con);
            DataTable dt = new DataTable();
            sdal.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page adm = new Admin_page();
            adm.Show();
        }
    }
}
