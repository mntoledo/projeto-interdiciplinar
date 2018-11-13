using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Importar biblioteca
using System.Data;
/// <summary>
/// Descrição resumida de AcademiaDB
/// </summary>
public class UsuarioDB
{
    // INSERT
    public static int Insert(Usuario usu)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO usu_usuario(usu_email, usu_senha, usu_perfil, usu_datacadastro) VALUES(?usu_email, ?usu_senha, ?usu_perfil, ?usu_datacadastro); select last_insert_id();";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usu.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha",usu.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_perfil", usu.Perfil));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_datacadastro", DateTime.Now));
            //objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            retorno = Convert.ToInt32(objCommand.ExecuteScalar());
            //Fecha a conexão
            objConexao.Close();
            //Disponibiliza o objeto conexão e o objeto comando para serem utilizados novamente –limpando a memória
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static int Update(Usuario usu)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE usu_usuario SET usu_email=?usu_email, usu_senha=?usu_senha, usu_perfil=?usu_perfil WHERE usu_codigo=?usu_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usu.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usu.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usu.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_perfil", usu.Perfil));
            objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            //Fecha a conexão
            objConexao.Close();
            //Disponibiliza o objeto conexão e o objeto comando para serem utilizados novamente –limpando a memória
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static int Delete(int codigo)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "DELETE FROM usu_usuario WHERE usu_codigo=?usu_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", codigo));
            objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            //Fecha a conexão
            objConexao.Close();
            //Disponibiliza o objeto conexão e o objeto comando para serem utilizados novamente –limpando a memória
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }
    // BUSCA
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuario ORDER BY usu_email", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Usuario Select(int codigo)
    {
        Usuario usu = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuario WHERE usu_codigo=?usu_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            usu = new Usuario();
            usu.Codigo = Convert.ToInt32(objDataReader["usu_codigo"]);
            usu.Email = Convert.ToString(objDataReader["usu_email"]);
            usu.Senha = Convert.ToString(objDataReader["usu_senha"]);
            usu.Perfil = Convert.ToString(objDataReader["usu_perfil"]);
            usu.DataCadastro = Convert.ToDateTime(objDataReader["usu_datacadastro"]);
        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return usu;
    }
}