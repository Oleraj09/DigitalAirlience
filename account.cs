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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "select *from users where email='" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update users set age=" + textBox5.Text + ",name='" + textBox2.Text + "',gender='" + textBox3.Text + "',nid='" + textBox6.Text + "',phone='" + textBox4.Text + "' where email='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Sucessfull! Going Home Page.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main hom = new main();
                hom.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error! Your Email Mismatched.!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
