using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Airlience_Systems
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        serverconnection con = new serverconnection();
        string query;
        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!authenticate())
            {
                MessageBox.Show("Empty News is not valid for Post!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string news = richTextBox1.Text;
            query = "insert into news(News) values('" + news + "')";
            con.setData(query);
            MessageBox.Show("News Added Sucessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AdminPanel ap =new AdminPanel();
            ap.Show();
            this.Hide();
        }

        bool authenticate()
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(panel1.Width==453 && panel1.Height==239)
            {
                panel1.Width = 0;
                panel1.Height = 0;
            }
            else
            {
                panel1.Width = 453;
                panel1.Height = 239;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateshedule up = new updateshedule();
            up.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hotellist hl = new hotellist();
            hl.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string plane = textBox1.Text;
            string city = textBox2.Text;
            string time = textBox3.Text;
            query = "insert into cityplane(Cities,Plane,Time) values('" + city + "','" + plane + "','" + time + "')";
            con.setData(query);
            MessageBox.Show("Details Added Sucessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(panel2.Width==468 && panel2.Height==180)
            {
                panel2.Width = 0;
                panel2.Height = 0;
            }
            else
            {
                panel2.Height = 180;
                panel2.Width = 468;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foodorders fo = new foodorders();
            fo.Show();
            this.Hide();
        }
    }
}
