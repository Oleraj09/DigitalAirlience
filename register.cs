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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        serverconnection con = new serverconnection();
        string query;
        private void button1_Click(object sender, EventArgs e)
        {
             if(!authenticate())
            {
                MessageBox.Show("Some Fields Are Empty! Must Fill All the Textbox.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = textBox1.Text;
            string email = textBox2.Text;
            string phone = textBox4.Text;
            string nid = textBox3.Text;
            string pass = textBox5.Text;
            string gender = comboBox1.Text;
            string age = textBox6.Text;
            //int age=int.parse(designTableName.Text);

            query = "insert into users(name,email,phone,nid,pass,age,gender) values('"+name+ "','" + email + "','" + phone + "','" + nid + "','" + pass + "'," + age + ",'"+gender+"')";
            //query="insert into users(age)values("+age+")";
            con.setData(query);
            MessageBox.Show("Account Successfully Created. Please Login!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            login log = new login();
            log.Show();
            this.Hide();



        }


        bool authenticate()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
                return false;
            else
                return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }
    }
}
