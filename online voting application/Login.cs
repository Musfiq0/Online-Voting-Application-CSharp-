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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
          
            textBox2.UseSystemPasswordChar = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome ob2 = new Welcome();
            ob2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");

            if (textBox1.Text != "" && textBox2.Text != "" && cmbUserType.Text != "")
            {
                if (cmbUserType.Text == "ADMIN")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Admin where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        Admin_page adm = new Admin_page();
                        adm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Account avilable with this Username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();

                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Users where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        User_Page up = new User_Page();
                        up.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

