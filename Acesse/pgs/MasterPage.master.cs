using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USUARIO"]==null)
        {
            btnEntrar.Visible = true;
            btnSair.Visible = false;
        }
        else
        {
            btnEntrar.Visible = false;
            btnSair.Visible = true;
        }
    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pgs/Login.aspx");
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/Default.aspx");
    }
}
