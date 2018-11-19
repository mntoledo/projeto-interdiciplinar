using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de ImagemDB
/// </summary>
public class ImagemDB
{
    // INSERT
    public static int Insert(Imagem img)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO img_imagem(img_codigo, img_descricao, img_data, loc_codigo) VALUES(?img_descricao, ?img_data, ?loc_codigo);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?img_descricao", img.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?img_data", DateTime.Now));
            objCommand.Parameters.Add(Mapped.Parameter("?loc_codigo", img.Local.Codigo));
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

    public static int Update(Imagem img)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE img_imagem SET img_descricao=?img_descricao, img_data=?img_data WHERE img_codigo=?img_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?img_codigo", img.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?img_descricao", img.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?img_data", img.Data));
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
            string sql = "DELETE FROM img_imagem WHERE img_codigo=?img_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?img_codigo", codigo));
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
        objCommand = Mapped.Command("SELECT * FROM img_imagem ORDER BY img_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Imagem Select(int codigo)
    {
        Imagem img = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM img_imagem WHERE img_codigo=?img_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?img_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            img = new Imagem();
            img.Codigo = Convert.ToInt32(objDataReader["img_codigo"]);
            img.Descricao = Convert.ToString(objDataReader["img_descricao"]);
            img.Data = Convert.ToDateTime(objDataReader["img_data"]);

            img.Local.Codigo = Convert.ToInt32(objDataReader["loc_codigo"]);
        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return img;
    }
    
}