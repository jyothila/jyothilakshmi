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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Class1 cs = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string s = "~/img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            int a = cs.query("insert into tb_project(username,password,emailid,mobno,country,image,datetime)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList1.SelectedValue + "','" + s + "','"+Label7.Text+"')");
            if (a > 0)
            {
                Response.Redirect("Mainhome.aspx");
                TextBox1.Text = "";
            }
        }

        protected void Unnamed1_Tick(object sender, EventArgs e)
        {
            Label7.Text = DateTime.Now.ToString();
        }
    }
}