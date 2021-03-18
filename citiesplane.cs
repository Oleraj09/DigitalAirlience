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
    public partial class citiesplane : Form
    {
        public citiesplane()
        {
            InitializeComponent();
            comboboxforcitiesplane();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");


        private void button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void citiesplane_Load(object sender, EventArgs e)
        {
            dispdata();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from cityplane where cities='" + comboBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            //MessageBox.Show("Finded sucessfully");
        }

        public void dispdata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from cityplane";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void comboboxforcitiesplane()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
            string city = "select *from cityplane";
            SqlCommand cmd = new SqlCommand(city,con1);
            SqlDataReader readcombo;
                try
            {
                con1.Open();
                readcombo = cmd.ExecuteReader();
                while(readcombo.Read())

                {
                    string cities = readcombo.GetString(0);
                    comboBox1.Items.Add(cities);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
          
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
