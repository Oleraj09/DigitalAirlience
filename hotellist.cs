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
    public partial class hotellist : Form
    {
        public hotellist()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select RoomNumber,Status from hotelbook where Email=@parm1", con);
            cmd.Parameters.AddWithValue("@parm1", textBox1.Text);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                textBox2.Text = reader1["RoomNumber"].ToString();
                textBox3.Text = reader1["Status"].ToString();

            }
            else
            {
                MessageBox.Show("No Data Found in this Case!", "Empty Box!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void dispdata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from hotelbook";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void hotellist_Load(object sender, EventArgs e)
        {
            dispdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update hotelbook set RoomNumber='" + textBox2.Text + "',Status='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            dispdata();
            MessageBox.Show("Room Details Update Sucessfully!", "Room Details!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }
    }
}
