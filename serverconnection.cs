using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Digital_Airlience_Systems
{
    class serverconnection
    {


        protected SqlConnection getConnection()
        {
            // it will set a connection with sql server 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-7AEHR9R; database=DigitalAirlience; integrated security = True";
            return con;
        }

        public DataSet getData(string query)//Extract data from the database
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query; //or
            //cmd.CommanndText = select * from login;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(String query)//Insertion Deletion Updating
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        /*public SqlDataReader getforCombo(String query)//combo box e show korte store thaka values
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
        */
    }
}
