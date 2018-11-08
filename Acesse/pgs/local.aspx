<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Local.aspx.cs" Inherits="pgs_local" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="container">
        <div class="col-12 col-sm-12 col-md-8 col-lg-8 mx-auto">
            <img src="../img/estabelecimentos/teste.jpg" class="img-fluid mb-3" alt="Restaurante com varias pessoas em suas mesas.">
        </div>
        <div class="col-12 col-sm-8 col-md-8 col-lg-8">
            <div class="col-12 col-sm-8 col-md-8 col-lg-4 bg-primary">
                <i class="fab fa-accessible-icon pr-3"></i>Acessivel a cadeirantes
            </div>
            <div class="col-12 col-sm-8 col-md-8 col-lg-4 bg-primary">
                <i class="fas fa-book-reader pr-3"></i>Tradutor de libras
            </div>
            <div class="col-12 col-sm-8 col-md-8 col-lg-4 bg-primary">
                <i class="fas fa-braille pr-3"></i>Menu em braile
            </div>

        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12">
            <h1>Restaurante</h1>
            <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Iste id corporis cupiditate voluptate placeat fuga illum minima natus possimus, culpa illo eum laborum aliquid non. Nisi vitae in provident tempora.
            </p>
        </div>
        <article class="col-md-12">
            <h2>Localização</h2>
            <p>Endereço: Rua exemplo n° 289 - Jardim das palmeiras - Guaratinguetá</p>
        </article>
    </section>
</asp:Content>

