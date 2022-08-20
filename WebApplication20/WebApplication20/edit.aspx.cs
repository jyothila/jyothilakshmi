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
    public partial class WebForm3 : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        string gid, un1;
        protected void Page_Load(object sender, EventArgs e)
        {
            gid = Request.Params["sid"].ToString();
            un1 = Session["uname"].ToString();
            if(!IsPostBack)
            {
                show();
            }
        }

        private void show()
        {
            SqlDataReader rdr = cs.read("select * from tb_project where id='" + gid + "'");
            if(rdr.Read())
            {
                TextBox1.Text = rdr["username"].ToString();
                TextBox2.Text = rdr["password"].ToString();
                TextBox3.Text = rdr["emailid"].ToString();
                TextBox4.Text = rdr["mobno"].ToString();
                DropDownList1.SelectedValue = rdr["country"].ToString();
                 Image1.ImageUrl = rdr["image"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            int a = cs.query("update tb_project set username='" + TextBox1.Text + "',password='" + TextBox2.Text + "',emailid='" + TextBox3.Text + "',mobno='" + TextBox4.Text + "',country='" + DropDownList1.SelectedValue + "',image='" + s + "' where id='" + gid + "'");
            if(a>0)
            {
                Response.Redirect("view.aspx");
            }
        }
    }
}