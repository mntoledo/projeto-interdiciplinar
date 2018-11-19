using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de VisualizacaoDB
/// </summary>
public class VisualizacaoDB
{
    // INSERT
    public static int Insert(Visualizacoes vis)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO vis_visualizacoes(vis_codigo, vis_datavisualizacao, loc_codigo) VALUES(?vis_codigo, ?vis_datavisualizacao, ?loc_codigo);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?vis_datavisualizacao", DateTime.Now));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_codigo", vis.Local.Codigo));
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

    public static int Update(Visualizacoes vis)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE vis_visualizacoes SET vis_datavisualizacao=?vis_datavisualizacao WHERE vis_codigo=?vis_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?vis_codigo", vis.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?vis_datavisualizacao", vis.DataVisualizacao));
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
            string sql = "DELETE FROM vis_visualizacoes WHERE vis_codigo=?vis_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?vis_codigo", codigo));
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
        objCommand = Mapped.Command("SELECT * FROM vis_visualizacoes ORDER BY vis_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Visualizacoes Select(int codigo)
    {
        Visualizacoes vis = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM vis_visualizacoes WHERE vis_codigo=?vis_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?vis_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            vis = new Visualizacoes();
            vis.Codigo = Convert.ToInt32(objDataReader["vis_codigo"]);
            vis.DataVisualizacao = Convert.ToDateTime(objDataReader["img_datavizualizacao"]);

            vis.Local.Codigo = Convert.ToInt32(objDataReader["loc_codigo"]);
        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return vis;
    }
}