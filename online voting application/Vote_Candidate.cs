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
    public partial class Vote_Candidate : Form
    {
        public Vote_Candidate()
        {
            InitializeComponent();
        }

        private void Vote_Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
            con.Open();
            SqlDataAdapter sdal = new SqlDataAdapter("Select eid, nid, name, gender, email, profession from Candidates", con);
            DataTable dt = new DataTable();
            sdal.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Candidates where nid='" + textBox1.Text + "'", con);
                DataTable dt2 = new DataTable();
                sda.Fill(dt2);
                int count = Convert.ToInt32(dt2.Rows[0]["vote"].ToString());
                count = count + 1;
                label1.Text = count.ToString();
                SqlCommand cmd = new SqlCommand("Update Candidates set vote='" + label1.Text + "' where nid='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                this.Hide();
                User_Page up1 = new User_Page();
                up1.Show();
            }
            else 
            {
                MessageBox.Show("Please enter the NID to Vote!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Page up1 = new User_Page();
            up1.Show();
        }
    }
}
