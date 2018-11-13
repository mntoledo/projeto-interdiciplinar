<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastrar.aspx.cs" Inherits="pgs_Cadastrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Entrar</title>
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
    <meta name="google-signin-client_id" content="772132630781-m1h3781q801ibsr9s5ieafp0qobctqse.apps.googleusercontent.com" />
    <script>
        function start() {
            gapi.load('auth2', function () {
                auth2 = gapi.auth2.init({
                    client_id: 'YOUR_CLIENT_ID.apps.googleusercontent.com',
                    // Scopes to request in addition to 'profile' and 'email'
                    //scope: 'additional_scope'
                });
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-6 col-md-6 bg-green h100 pt-5">
                <div class="mx-auto col-8 col-md-8 p-0 mt-5">
                    <p class="h2 text-center pb-4">Encontre locais com acessibilidade mais próximo a você.</p>
                    <img src="../img/icones-tela-de-login.png" class="img-fluid mt-5" alt="Icones de pessoas com deficiência" />
                </div>
            </div>
            <div class="col-6 col-md-6 p-0 h100">
                <div class="col-8 col-md-8 pt-5 mx-auto">
                    <h1 class="pt-4">Cadastrar</h1>
                    <div class="form-group mt-5">
                        <label for="txtNome">Nome</label>
                        <asp:TextBox ID="txtNome" runat="server" type="text" CssClass="form-control" required="required"></asp:TextBox>
                        <label for="txtSobrenome">Sobrenome</label>
                        <asp:TextBox ID="txtSobrenome" type="text" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        <label for="txtEmail">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" type="email" CssClass="form-control" required="required"></asp:TextBox>
                        <label for="txtSenha">Senha</label>
                        <asp:TextBox ID="txtSenha" type="password" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        <label for="txtSenha">Confirmar Senha</label>
                        <asp:TextBox ID="txtConfirmarSenha" type="password" runat="server" CssClass="form-control" required="required"></asp:TextBox>

                        <asp:Button ID="btnEntrar" CssClass="btn bg-green mt-3 mb-4" runat="server" Text="Cadastrar" OnClick="btnEntrar_Click" />

                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <script>
        function onSignIn(googleUser) {
            var profile = googleUser.getBasicProfile();
            console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
            console.log('Name: ' + profile.getName());
            console.log('Image URL: ' + profile.getImageUrl());
            console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
        }
    </script>
</body>
</html>
