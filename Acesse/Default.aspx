<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="bg-search">
        <div class="bg-acess bg-acess-opacity">
            <h1 class="text-center">Pesquise</h1>
            <div class="d-flex mx-auto col-12 col-sm-10 col-md-8 col-lg-6">
                <asp:TextBox ID="txtBusca" runat="server" tabindex="8" placeholder="Digite o nome de um local ou cidade" title="Buscar local"  CssClass="input"></asp:TextBox>
                <asp:Button ID="btnBusca" tabindex="9" CssClass="btn btn-success button" runat="server" Text="Buscar" />
            </div>
        </div>
    </section>

    <section class="container  mt-5" role="main">
        <h3 class="text-center mt-4">Locais com acessibilidade</h3>
        <div class="card-deck ">
            <div class="col-12 col-sm-12 col-md-6 col-lg-3">
                <div class="card mx-auto" style="width: 18rem;">
                    <img class="card-img-top" src="img/estabelecimentos/teste.jpg" alt="Restaurante com pessoas sentadas a mesa">
                    <div class="card-body">
                        <h5 class="card-title">Restaurante</h5>
                        <p class="card-text">
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.
                        </p>
                        <a href="pgs/local.aspx" class="btn btn-primary mx-auto" tabindex="9">Ver Detalhes</a>
                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-6 col-lg-3">
                <div class="card mx-auto" style="width: 18rem;">
                    <img class="card-img-top" src="img/estabelecimentos/teste.jpg" alt="Restaurante com pessoas sentadas a mesa">
                    <div class="card-body">
                        <h5 class="card-title">Restaurante</h5>
                        <p class="card-text">
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.
                        </p>
                        <a href="#" class="btn btn-primary mx-auto" tabindex="9">Ver Detalhes</a>
                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-6 col-lg-3">
                <div class="card mx-auto" style="width: 18rem;">
                    <img class="card-img-top" src="img/estabelecimentos/teste.jpg" alt="Restaurante com pessoas sentadas a mesa">
                    <div class="card-body">
                        <h5 class="card-title">Restaurante</h5>
                        <p class="card-text">
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.
                        </p>
                        <a href="#" class="btn btn-primary mx-auto" tabindex="9">Ver Detalhes</a>
                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-6 col-lg-3">
                <div class="card mx-auto" style="width: 18rem;">
                    <img class="card-img-top" src="img/estabelecimentos/teste.jpg" alt="Restaurante com pessoas sentadas a mesa">
                    <div class="card-body">
                        <h5 class="card-title">Restaurante</h5>
                        <p class="card-text">
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.
                        </p>
                        <a href="#" class="btn btn-primary mx-auto" tabindex="9">Ver Detalhes</a>
                    </div>
                </div>
            </div>
        </div>

        <article class="col-12 col-sm-12 col-md-12 col-lg-12 mt-5">
            <h2 class="text-center">Quem Somos</h2>
            <div class="row">
                <div class="col-lg-6 d-flex align-items-center">
                    <p class="lead">
                        Nós somos uma plataforma que busca fazer a inclusão de pessoas com algum tipo de deficiência
                        por
                        meio
                        da divulgação de informações sobre locais acessíveis.
                    </p>
                </div>
                <div class="col-lg-6">
                    <figure class="figure">
                        <img src="img/pessoas.jpg" class="figure-img img-fluid rounded" alt="Imagem com icones de pessoas com defeciência.">
                    </figure>
                </div>
            </div>
        </article>
    </section>
</asp:Content>

