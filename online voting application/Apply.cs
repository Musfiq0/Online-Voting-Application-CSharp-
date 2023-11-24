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
    public partial class Apply : Form
    {
        public Apply()
        {
            InitializeComponent();
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
            con.Open();
            SqlDataAdapter sdal = new SqlDataAdapter("Select * from election", con);
            DataTable dt = new DataTable();
            sdal.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert Into Candidates(nid, name, gender, email, profession) select nid, name, gender, email, profession from Users where username='"+textBox2.Text+"'", con);
                SqlCommand cmd1 = new SqlCommand("Update Candidates set eid='" + textBox1.Text + "', vote='"+0+"' where nid=nid", con);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("You have applied to Election No. "+textBox1.Text, "APPLIED", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter the Election ID and Username!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vote_Candidate vp = new Vote_Candidate();
            vp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Page f1 = new User_Page();
            f1.Show();
        }
    }
}
