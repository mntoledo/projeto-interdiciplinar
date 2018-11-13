using System;
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
            string sql = "INSERT INTO pes_pessoa(pes_codigo,pes_nome, pes_sobrenome, pes_cpf, pes_rg, usu_usuario_usu_codigo,usu_perfil) VALUES(0,?pes_nome, ?pes_sobrenome, ?pes_cpf, ?pes_rg, ?usu_usuario_usu_codigo,'Comum');";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pes.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", pes.SobreNome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", pes.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", pes.RG));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_usuario_usu_codigo", pes.Usuario.Codigo));
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
}