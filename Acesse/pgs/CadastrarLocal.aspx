<%@ Page Title="" Language="C#" MasterPageFile="~/pgs/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarLocal.aspx.cs" Inherits="pgs_CadastrarLocal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="col-md-8 mx-auto">
            <h1>Cadastro de local</h1>
            <div class="form-group">
                <label>Nome</label>
                <asp:TextBox ID="txtNomeLocal" runat="server" CssClass="form form-control"></asp:TextBox>
                <label>CNPJ</label>
                <asp:TextBox ID="txtCNPJ" runat="server" CssClass="form form-control"></asp:TextBox>
                <label>Descrição</label>
                <asp:TextBox ID="txtDescricaoLocal" runat="server" CssClass="form form-control"></asp:TextBox>
                <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                <asp:Button ID="btnLocalizacao" runat="server" Text="Adicionar localização" CssClass="btn bg-green mt-3" />
                <h2>O que o seu local tem de acessivel?</h2>
                <div class="row">
                    <div class="col-md-6">
                        <div class="custom-control custom-checkbox">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <label for="CheckBox1">Rampas</label><br />

                            <asp:CheckBox ID="CheckBox2" runat="server" />
                            <label for="CheckBox2">Corrimão</label><br />

                            <asp:CheckBox ID="CheckBox3" runat="server" />
                            <label for="CheckBox3">Texto em braile</label>
                            <br />

                            <asp:CheckBox ID="CheckBox4" runat="server" />
                            <label for="CheckBox4">Tradutor de libras</label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="custom-control custom-checkbox">
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                            <label for="CheckBox5">Sanitário acessível</label>

                            <asp:CheckBox ID="CheckBox6" runat="server" />
                            <label for="CheckBox6">Vagas de estacionamento reservadas</label>

                            <asp:CheckBox ID="CheckBox7" runat="server" />
                            <label for="CheckBox7">Piso tátil</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12 mx-auto">
                <img src="../img/estabelecimentos/teste.jpg" class="img-fluid" />
                <asp:Button ID="btnAdicionarImagem" runat="server" Text="Adicionar imagem" CssClass="btn bg-green mt-3 mb-3" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnCadastrarLocal" runat="server" CssClass="btn bg-green mb-3" Text="Cadastrar" />
            </div>
        </div>
    </div>
</asp:Content>

