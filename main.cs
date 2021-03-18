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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(panel3.Height==139)
            {
                panel3.Height = 36;
            }
            else
            {
                panel3.Height = 139;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (panel1.Height == 125)
            {
                panel1.Height = 36;
            }
            else
            {
                panel1.Height = 125;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel2.Height == 100)
            {
                panel2.Height = 36;
            }
            else
            {
                panel2.Height = 100;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digitalAirlienceDataSet.news' table. You can move, or remove it, as needed.
            this.newsTableAdapter.Fill(this.digitalAirlienceDataSet.news);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            recent_flight recent = new recent_flight();
            recent.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookseat book = new bookseat();
            book.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            citiesplane cp = new citiesplane();
            cp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hotelbook hb = new hotelbook();
            hb.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            orderfood of = new orderfood();
            of.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            account acc = new account();
            acc.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cancelticket ct = new cancelticket();
            ct.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            viewroom vr = new viewroom();
            vr.Show();
            this.Hide();
        }
    }
}
