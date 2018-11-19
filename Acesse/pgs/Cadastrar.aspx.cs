using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgs_Cadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {

        Pessoa pes = new Pessoa();
        pes.Nome = txtNome.Text;
        pes.SobreNome = txtSobrenome.Text;

        pes.Usuario = new Usuario();
        pes.Usuario.Email = txtEmail.Text;
        pes.Usuario.Senha = txtSenha.Text;
        pes.Usuario.Perfil = "Comum";

        pes.Usuario.Codigo = UsuarioDB.Insert(pes.Usuario);
        if (pes.Usuario.Codigo != -2)
        {
            if (PessoaDB.Insert(pes) != -2)
            {
                Response.Redirect("local.aspx");
                //Response.Write("<script>alert('Cadastro com sucesso')</script>");
            }
            else
                Response.Write("<script>alert('Erro Pessoa')</script>");
        }
        else
            Response.Write("<script>alert('Erro usuario')</script>");
    }
}