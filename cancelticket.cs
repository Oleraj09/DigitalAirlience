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
    public partial class cancelticket : Form
    {
        public cancelticket()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
        private void button3_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Phone,Departure,Destination,Seat from buyticket where TicketID=@parm1",con);
            cmd.Parameters.AddWithValue("@parm1", textBox1.Text);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                textBox2.Text = reader1["Name"].ToString();
                textBox3.Text = reader1["Phone"].ToString();
                textBox4.Text = reader1["Departure"].ToString();
                textBox5.Text = reader1["Destination"].ToString();
                textBox6.Text = reader1["Seat"].ToString();

            }
            else
            {
                MessageBox.Show("No Data Find in this Case!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from buyticket where TicketID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            empty();
            MessageBox.Show("Successfully Canceled Your Ticked!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select TicketID from buyticket where Phone=@parm2", con);
            cmd.Parameters.AddWithValue("@parm2", textBox7.Text);
            SqlDataReader reader2;
            reader2 = cmd.ExecuteReader();
            if (reader2.Read())
            {
                textBox1.Text = reader2["TicketID"].ToString();

            }
            else
            {
                MessageBox.Show("No Data Find in this Case!", "Authentication Problem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
    }
}
