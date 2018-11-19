using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Local
/// </summary>
public class Local
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Tipo { get; set; }
    public Acessibilidade Acessibilidade { get; set; }
}