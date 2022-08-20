using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication20
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["uname"] = TextBox1.Text;
            SqlDataReader rd=cs.read("select * from tb_project where username='"+TextBox1.Text+"'and password='"+TextBox2.Text+"'");
            if(rd.Read())
            {
                Response.Redirect("view.aspx");
            }
        }
    }
}