using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de LocalDB
/// </summary>
public class LocalDB
{

    // INSERT
    public static int Insert(Local loc)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO loc_local(loc_nome, loc_descricao, loc_categoria, loc_tipo, ace_codigo) VALUES(?loc_nome, ?loc_descricao, ?loc_categoria, ?loc_tipo, ?ace_codigo);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?loc_nome", loc.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_descricao", loc.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_categoria", loc.Categoria));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_tipo", loc.Tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?ace_codigo", loc.Acessibilidade.Codigo));
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

    public static int Update(Local loc)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE loc_local SET loc_nome=?loc_nome, loc_descricao=?loc_descricao, loc_categoria=?loc_categoria, loc_tipo=?loc_tipo WHERE loc_codigo=?loc_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?loc_nome", loc.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_descricao", loc.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_categoria", loc.Categoria));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_tipo", loc.Tipo));
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
            string sql = "DELETE FROM loc_local WHERE loc_codigo=?loc_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?loc_codigo", codigo));
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
        objCommand = Mapped.Command("SELECT * FROM loc_local ORDER BY loc_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Local Select(int codigo)
    {
        Local loc = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM loc_local WHERE loc_codigo=?loc_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?loc_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            loc = new Local();
            loc.Codigo = Convert.ToInt32(objDataReader["loc_codigo"]);
            loc.Nome = Convert.ToString(objDataReader["loc_nome"]);
            loc.Descricao = Convert.ToString(objDataReader["loc_descricao"]);
            loc.Categoria = Convert.ToString(objDataReader["loc_categoria"]);
            loc.Tipo = Convert.ToString(objDataReader["loc_tipo"]);

            loc.Acessibilidade.Codigo = Convert.ToInt32(objDataReader["ace_codigo"]);
        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return loc;
    }
    
}