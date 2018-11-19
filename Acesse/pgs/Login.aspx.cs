using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class pgs_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Response.Redirect("local.aspx", false);
    }


    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != "" && txtSenha.Text != "")
        {
            Pessoa pes = UsuarioDB.ValidaAcesso(txtEmail.Text, txtSenha.Text);
            if (pes != null)
            {
                Session["USUARIO"] = pes;
                Response.Redirect("Local.aspx", false);
            }
            else
                Response.Write("<script>alert('Login e senha inválido')</script>");
        }
        else
            Response.Write("<script>alert('Preencha login e senha')</script>");
    }
}