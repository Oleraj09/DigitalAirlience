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
    public partial class foodorders : Form
    {
        public foodorders()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dispdata();
        }

        public void dispdata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from orderfood";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from orderfood where Phone='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            dispdata();
            MessageBox.Show("Order Successfully Completed!", "Order Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }

        private void foodorders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digitalAirlienceDataSet7.orderfood' table. You can move, or remove it, as needed.
            this.orderfoodTableAdapter.Fill(this.digitalAirlienceDataSet7.orderfood);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
