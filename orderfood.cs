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
    public partial class orderfood : Form
    {
        public orderfood()
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string order = comboBox1.Text;
            string adress = richTextBox1.Text;
            string name = textBox2.Text;
            string phone = textBox1.Text;
            //int age=int.parse(designTableName.Text);

            query = "insert into orderfood(Ordertype,Name,Phone,Adress) values('" + order + "','" + name + "','" + phone + "','" + adress + "')";
            //query="insert into users(age)values("+age+")";
            con.setData(query);
            MessageBox.Show("Cash On Delevary is Sucessfully! Your Order will Serve Soon!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            main hom = new main();
            hom.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="BreakFast")
            {
                textBox3.Text = (480).ToString();
            }
            else if (comboBox1.Text == "Launch")
            {
                textBox3.Text = (520).ToString();
            }
            else
            {
                textBox3.Text = (750).ToString();
            }
            //textBox3.Text = (float.Parse(comboBox1.Text) * 7500).ToString();
        }
    }
}
