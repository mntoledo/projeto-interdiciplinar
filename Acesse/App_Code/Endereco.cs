using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Endereco
/// </summary>
public class Endereco
{
    public int Codigo { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    public Usuario Usuario { get; set; }
    public Local Local { get; set; }
}