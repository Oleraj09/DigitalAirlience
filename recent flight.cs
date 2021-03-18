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
    public partial class recent_flight : Form
    {
        public recent_flight()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void recent_flight_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digitalAirlienceDataSet2.recentflight' table. You can move, or remove it, as needed.
            this.recentflightTableAdapter1.Fill(this.digitalAirlienceDataSet2.recentflight);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            main hom = new main();
            hom.Show();
            this.Hide();
        }
    }
}
