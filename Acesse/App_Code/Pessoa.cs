using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Pessoa
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public Usuario Usuario { get; set; }
}