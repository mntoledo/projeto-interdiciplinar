using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de EnderecoDB
/// </summary>
public class EnderecoDB
{

    // INSERT
    public static int Insert(Endereco end)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO end_endereco(end_codigo, end_logradouro, end_numero, end_bairro, end_cidade, end_estado, end_cep, usu_codigo, end_codigo)" +
                "VALUES(?end_codigo, ?end_logradouro, ?end_numero, ?end_bairro, ?end_cidade, ?end_estado, ?end_cep, ?usu_codigo, ?loc_codigo);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", end.Logradouro));
            objCommand.Parameters.Add(Mapped.Parameter("?end_numero", end.Numero));
            objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", end.Bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cidade", end.Cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?end_estado", end.Estado));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", end.Cep));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", end.Usuario.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_codigo", end.Local.Codigo));
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

    public static int Update(Endereco end)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE end_endereco SET end_logradouro=?end_logradouro, end_numero=?end_numero, end_bairro=?end_bairro, end_cidade=?end_cidade, end_estado=?end_estado, end_cep=?end_cep WHERE end_codigo=?end_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", end.Logradouro));
            objCommand.Parameters.Add(Mapped.Parameter("?end_numero", end.Numero));
            objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", end.Bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cidade", end.Cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?end_estado", end.Estado));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", end.Cep));
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
            string sql = "DELETE FROM end_endereco WHERE end_codigo=?end_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", codigo));
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
        objCommand = Mapped.Command("SELECT * FROM end_endereco ORDER BY end_cep", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Endereco Select(int codigo)
    {
        Endereco end = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM end_endereco WHERE end_codigo=?end_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            end = new Endereco();
            end.Codigo = Convert.ToInt32(objDataReader["end_codigo"]);
            end.Logradouro = Convert.ToString(objDataReader["end_logradouro"]);
            end.Numero = Convert.ToString(objDataReader["end_numero"]);
            end.Bairro = Convert.ToString(objDataReader["end_bairro"]);
            end.Cidade = Convert.ToString(objDataReader["end_cidade"]);
            end.Estado = Convert.ToString(objDataReader["end_estado"]);
            end.Cep = Convert.ToString(objDataReader["end_cep"]);

            end.Usuario.Codigo = Convert.ToInt32(objDataReader["usu_codigo"]);
            end.Local.Codigo = Convert.ToInt32(objDataReader["loc_codigo"]);
        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return end;
    }
}