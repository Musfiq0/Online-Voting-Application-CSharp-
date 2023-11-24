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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            textBox11.UseSystemPasswordChar = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox11.UseSystemPasswordChar = true;
            }
            else
            {
                textBox11.UseSystemPasswordChar = false;
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Welcome ob3 = new Welcome();
            ob3.Show();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
     
        private void textBox3_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(textBox3.Text.Trim());
            if (!isValid)
            {
                MessageBox.Show("Invalid Email.");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox14.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox9.Text != "" && textBox7.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && textBox15.Text != "" && textBox11.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Users]
           ([nid]
           ,[name]
           ,[fathersname]
           ,[mothersname]
           ,[gender]
           ,[address]
           ,[email]
           ,[phone]
           ,[dob]
           ,[profession]
           ,[username]
           ,[password])
     VALUES
           ('" + textBox14.Text + "', '" + textBox6.Text + "', '" + textBox5.Text + "', '" + textBox9.Text + "', '" + cmbGender.SelectedItem.ToString() + "', '" + textBox7.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + textBox1.Text + "', '" + textBox15.Text + "', '" + textBox11.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registered Successfully");

            }
            else
            {
                MessageBox.Show("Please complete the entire form!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void clear()
        {
            textBox14.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox9.Clear();
            cmbGender.Text="";
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Text = null; 
            textBox1.Clear();
            textBox15.Clear();
            textBox11.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
