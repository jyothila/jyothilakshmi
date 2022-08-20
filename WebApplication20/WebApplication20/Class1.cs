using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication20
{
    public class Class1
    {
        SqlConnection con;
        SqlCommand cmd;
        public Class1()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-UMGJSP7;Initial Catalog=jyothi;Integrated Security=True");
        }
       public int query(string str)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd = new SqlCommand(str, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public DataSet select(string str)
        {
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            con.Close();
            return ds;
        }
        public SqlDataReader read(string str)
        {
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}