using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    public int Codigo { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Perfil { get; set; }
    public DateTime DataCadastro { get; set; }
}