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
    public partial class viewroom : Form
    {
        public viewroom()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Quality,RoomNumber,Status from hotelbook where Email=@parm1", con);
            cmd.Parameters.AddWithValue("@parm1", textBox1.Text);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                textBox5.Text = reader1["Name"].ToString();
                textBox4.Text = reader1["Quality"].ToString();
                textBox2.Text = reader1["RoomNumber"].ToString();
                textBox6.Text = reader1["Status"].ToString();

            }
            else
            {
                MessageBox.Show("No data found!");
            }
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }
    }
}
