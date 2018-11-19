using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgs_local : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USUARIO"]==null)
            Response.Redirect("login.aspx", false);

        Pessoa pes = (Pessoa)Session["USUARIO"];
        //lbl=pes.Nome
    }
}