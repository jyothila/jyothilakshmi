using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication20
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        string un1;
        protected void Page_Load(object sender, EventArgs e)
        {
            un1 = Session["uname"].ToString();
            if(!IsPostBack)
            {
                show();
            }
        }

        private void show()
        {
            DataSet ds = cs.select("select * from tb_project where username='"+un1+"'");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lntbn = sender as LinkButton;
            GridViewRow gvrow = lntbn.NamingContainer as GridViewRow;
            int gid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
           int a= cs.query("delete from tb_project where id='" + gid + "'");
            show();
            
            
           
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainhome.aspx");
        }
    }
}