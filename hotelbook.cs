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
    public partial class hotelbook : Form
    {
        public hotelbook()
        {
            InitializeComponent();
        }
        serverconnection con = new serverconnection();
        string query;
        private void button2_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!authenticateh())
            {
                MessageBox.Show("You Must Send Money From Bkash TO complete Order!", "Payment Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string bkash = textBox3.Text;
            string email1 = textBox6.Text;
            string trx = textBox1.Text;

            query = "insert into paymenthotel(BkashNumber,BkashTRX,Email) values('" + bkash + "','" + trx + "','"+email1+"')";
            //query="insert into users(age)values("+age+")";
            con.setData(query);

            MessageBox.Show("Seat Will Booked for You after verify payment. Thank You!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            viewroom vr = new viewroom();
            vr.Show();
            this.Hide();
        }

        bool authenticateh()
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text))
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!authentication())
            {
                MessageBox.Show("Error! Emply Boxes Not Allowed!", "Empty Box!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = textBox4.Text;
            string email = textBox2.Text;
            string quality = comboBox1.Text;
            string room = comboBox2.Text;
            string date = dateTimePicker1.Text;
            string roomnumber = "Pending";
            string status = "Pending";
            
            query = "insert into hotelbook(Name,Email,Quality,Date,Room,RoomNumber,Status) values('" + name + "','" + email + "','" + quality + "','" + date + "','" + room + "','"+roomnumber+"','"+status+"')";
            //query="insert into users(age)values("+age+")";
            con.setData(query);

            if (panel1.Height==306 && panel1.Width==288)
            {
                panel1.Width = 0;
                panel1.Height = 0;
            }
            else
            {
                panel1.Height = 306;
                panel1.Width = 288;
            }
        }

        bool authentication()
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                return false;
            else
                return true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = (float.Parse(comboBox2.Text) * 350).ToString();
            
        }
    }
}
