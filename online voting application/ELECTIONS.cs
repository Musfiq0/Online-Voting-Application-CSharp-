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
    public partial class ELECTIONS : Form
    {
        public ELECTIONS()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page adm = new Admin_page();
            adm.Show();
        }
        //create
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox1.Text!=""|| textBox4.Text != "" || dateTimePicker2.Text != "" || dateTimePicker1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[election]
           ([eid]
           ,[title]
           ,[start]
           ,[finish]
           ,[description])
     VALUES
           ('" + textBox2.Text + "', '" + textBox1.Text + "', '" + dateTimePicker2.Value.ToString() + "', '" + dateTimePicker1.Value.ToString() + "', '" + textBox4.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data insterted successfully!", "Inserted", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please complete the entire form!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //show
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
            con.Open();
            SqlDataAdapter sdal = new SqlDataAdapter("Select * from election", con);
            DataTable dt = new DataTable();
            sdal.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //update
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con2 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con2.Open();
                SqlCommand cmd = new SqlCommand("Update election set title='" + textBox1.Text + "', start='"+dateTimePicker2.Value.ToString() + "', finish='"+dateTimePicker1.Value.ToString() + "', description='"+textBox4.Text+"' where eid='"+textBox2.Text+"'",con2);
                cmd.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("Data updated successfully", "Updated", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter the Election ID!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con3 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con3.Open();
                SqlCommand cmd = new SqlCommand("Delete from election where eid='" + textBox2.Text + "'", con3);
                cmd.ExecuteNonQuery();
                con3.Close();
                MessageBox.Show("Data deleted successfully", "Deleted", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter the Election ID!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //search
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con4 = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                con4.Open();
                SqlDataAdapter sdal2 = new SqlDataAdapter("Select * from election where eid='" + textBox2.Text + "'", con4);
                DataTable dt2 = new DataTable();
                sdal2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt2;
                    con4.Close();
                }
                else
                {
                    MessageBox.Show("Election Not Found!", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter the Election ID!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

