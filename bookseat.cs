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
    public partial class bookseat : Form
    {
        public bookseat()
        {
            InitializeComponent();
            //comboboxfordestination();
            //comboboxfordestination();

        }

        /*public void comboboxfordeparture()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
            string departure = "select *from cityplane";
            SqlCommand cmd = new SqlCommand(departure, con1);
            SqlDataReader readcombo1;
            try
            {
                con1.Open();
                readcombo1 = cmd.ExecuteReader();
                while (readcombo1.Read())

                {
                    string cities = readcombo1.GetString(0);
                    comboBox1.Items.Add(cities);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void comboboxfordestination()
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-7AEHR9R;Initial Catalog=DigitalAirlience;Integrated Security=True");
            string destination = "select *from cityplane";
            SqlCommand cmd = new SqlCommand(destination, con2);
            SqlDataReader readcombo2;
            try
            {
                con2.Open();
                readcombo2 = cmd.ExecuteReader();
                while (readcombo2.Read())

                {
                    string cities = readcombo2.GetString(0);
                    comboBox2.Items.Add(cities);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        */

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }
        serverconnection con = new serverconnection();
        string query;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if(!authentication())
            {
                MessageBox.Show("Empty Box Detected!");
                return;
            }
            string name = textBox1.Text;
            string phone = textBox2.Text;
            string from = comboBox1.Text;
            string to = comboBox2.Text;
            string date = dateTimePicker1.Text;
            string seat = comboBox3.Text;
            query = "insert into buyticket(Name,Phone,Departure,Destination,Time,Seat) values('" + name + "','" + phone + "','" + from + "','" + to + "','" + date + "',"+seat+")";
            //query="insert into users(age)values("+age+")";
            con.setData(query);

            if (panel1.Height == 308 && panel1.Width == 288)
            {
                panel1.Height = 0;
                panel1.Width = 0;
            }
            else
            {
                panel1.Height = 308;
                panel1.Width = 288;
            }
            //MessageBox.Show("Seat Booked For You!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //main hom = new main();
            //hom.Show();
            //this.Hide();
        }
        bool authentication()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                return false;
            else
                return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!authenticatep())
            {
                MessageBox.Show("You Must Send Money From Bkash TO complete Order!","Payment Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string bkash = textBox3.Text;
            string amount = textBox6.Text;
            string trx = textBox4.Text;
            
            query = "insert into payment(BkashNumber,BkashTrxID,Amount) values('" + bkash + "','" + trx + "'," + amount + ")";
            //query="insert into users(age)values("+age+")";
            con.setData(query);

            MessageBox.Show("Seat Will Booked for You after verify payment. Thank You!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        bool authenticatep()
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) )
                return false;
            else
                return true;
        }

        private void bookseat_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = (float.Parse(comboBox3.Text) * 7500).ToString();
            textBox6.Text = (float.Parse(comboBox3.Text) * 7500).ToString();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
