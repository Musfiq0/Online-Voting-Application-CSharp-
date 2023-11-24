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
    public partial class USER : Form
    {
        public USER()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page a1 = new Admin_page();
            a1.Show();
        }
        //show
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
            con.Open();
            SqlDataAdapter sdal = new SqlDataAdapter("Select * from Users", con);
            DataTable dt = new DataTable();
            sdal.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //update
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                SqlConnection con2 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con2.Open();
                SqlCommand cmd = new SqlCommand("Update Users set nid='" + textBox1.Text + "', name='" + textBox2.Text + "', fathersname='" + textBox3.Text + "', mothersname='" + textBox4.Text + "', gender='" + cmbGender.Text + "', address='" + textBox5.Text + "', email='" + textBox6.Text + "', phone='" + textBox7.Text + "', dob='" + dateTimePicker1.Value.ToString() + "', profession='" + textBox8.Text + "' where username='" + textBox9.Text + "'", con2);
                cmd.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("Data updated successfully", "Updated", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter the Username!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                SqlConnection con3 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con3.Open();
                SqlCommand cmd = new SqlCommand("Delete from Users where username='" + textBox9.Text + "'", con3);
                cmd.ExecuteNonQuery();
                con3.Close();
                MessageBox.Show("User deleted successfully", "Deleted", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter the Username!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Search
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "" )
            {
                SqlConnection con4 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con4.Open();
                SqlDataAdapter sdal2 = new SqlDataAdapter("Select * from Users where username='" + textBox9.Text + "'", con4);
                DataTable dt2 = new DataTable();
                sdal2.Fill(dt2);
                if (dt2.Rows.Count >0)
                {
                    dataGridView1.DataSource = dt2;
                    con4.Close();
                }
                else
                {
                    MessageBox.Show("User Not Found!", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter the Username!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
