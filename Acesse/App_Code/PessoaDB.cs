﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de PessoaDB
/// </summary>
public class PessoaDB
{
    public static int Insert(Pessoa pes)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "INSERT INTO pes_pessoa(pes_codigo, pes_nome, pes_sobrenome, pes_cpf, pes_rg, usu_codigo) VALUES(?pes_codigo, ?pes_nome, ?pes_sobrenome, ?pes_cpf, ?pes_rg, ?usu_codigo);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pes.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", pes.SobreNome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", pes.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", pes.RG));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", pes.Usuario.Codigo));
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

    public static int Update(Pessoa pes)
    {

        int retorno = 0;
        try
        {
            IDbConnection objConexao; // Abre a conexao
            IDbCommand objCommand; // Cria o comando
            string sql = "UPDATE pes_pessoa SET pes_nome=?pes_nome, pes_sobrenome=?pes_sobrenome, pes_cpf=?pes_cpf, loc_tipo=?loc_tipo WHERE loc_codigo=?loc_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pes.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", pes.SobreNome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", pes.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", pes.RG));
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
            string sql = "DELETE FROM pes_pessoa WHERE pes_codigo=?pes_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", codigo));
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
        objCommand = Mapped.Command("SELECT * FROM pes_pessoa ORDER BY pes_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, O método Fill é o responsável por preencher o DataSet         
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static Pessoa Select(int codigo)
    {
        Pessoa pes = null;
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataReader objDataReader;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pes_pessoa WHERE pes_codigo=?pes_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            pes = new Pessoa();
            pes.Codigo = Convert.ToInt32(objDataReader["pes_codigo"]);
            pes.Nome = Convert.ToString(objDataReader["pes_nome"]);
            pes.SobreNome = Convert.ToString(objDataReader["pes_sobrenome"]);
            pes.CPF = Convert.ToString(objDataReader["pes_cpf"]);
            pes.RG = Convert.ToString(objDataReader["pes.rg"]);

            pes.Usuario.Codigo = Convert.ToInt32(objDataReader["usu_codigo"]);

        }
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return pes;
    }
}