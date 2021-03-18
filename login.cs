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

namespace Digital_Airlience_Systems
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(panel1.Width==355 && panel1.Height==338)
            {
                panel1.Width = 0;
                panel1.Height = 0;
            }
            else
            {
                panel1.Width = 355;
                panel1.Height = 338;
            }
            //Admin a = new Admin();
            //a.Show();
            //this.Hide();
        }

        //serverconnection con = new serverconnection();
        //string query;

        private void button1_Click(object sender, EventArgs e)
        {
            if(!authenticate())
            {
                MessageBox.Show("Some Fields Are Empty! Must Fill All the Textbox.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
                string query = "select *from users where email='" + textBox1.Text.Trim() + "' and pass='" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    //MessageBox.Show("Login Sucessfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main hom = new main();
                    hom.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error! Email Or Password is wrong!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            

        }
        bool authenticate()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
                return false;
            else
                return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!authenticatea())
            {
                MessageBox.Show("Some Fields Are Empty! Must Fill All the Textbox.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (textBox3.Text == "Admin" && textBox4.Text == "Admin09")
                {
                    //MessageBox.Show("Admin Panel Login Sucessfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminPanel ap = new AdminPanel();
                    ap.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error! Email Or Password is wrong!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        bool authenticatea()
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
                return false;
            else
                return true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /*private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linkLabel2.Text=="Show")
            {
                textBox2.PasswordChar = '\0';
                linkLabel2.Text = "Hide";
            }
            else
            {
                textBox2.PasswordChar = '*';
                linkLabel2.Text = "Show";
            }
        }*/

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
                
            }
            else
            {
                textBox2.PasswordChar = '*';
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
