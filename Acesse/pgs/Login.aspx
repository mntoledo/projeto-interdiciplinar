<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="pgs_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Entrar</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
    <meta name="google-signin-client_id" content="772132630781-m1h3781q801ibsr9s5ieafp0qobctqse.apps.googleusercontent.com">
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
            <div class="col-6 col-md-6 bg-green h100">
                <div class="mx-auto col-8 col-md-8 p-0 mt-5">
                    <p class="h2">Encontre locais com acessibilidade mais próximo a você.</p>
                    <img src="../img/icones-tela-de-login.png" class="img-fluid" alt="Icones de pessoas com deficiência" />
                </div>
            </div>
            <div class="col-6 col-md-6 p-0 h100">
                <div class="col-8 col-md-8 pt-5 mx-auto">
                    <h1>Fazer login com</h1>
                    <div class="g-signin2" data-onsuccess="onSignIn"></div>
                    <form action="/" method="post" class="form-group mt-5">
                        <label for="txtEmail">Nome</label>
                        <asp:TextBox ID="txtEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>
                        <label for="txtSenha">Senha</label>
                        <asp:TextBox ID="txtSenha" type="password" runat="server" CssClass="form-control"></asp:TextBox>
                        <div class="form-group form-check mt-3">
                            <input type="checkbox" class="form-check-input" id="exampleCheck1">
                            <label class="form-check-label" for="exampleCheck1">Manter conectado!</label>

                            <a href="#" class="float-right">Esqueceu a senha</a>
                        </div>
                        <asp:Button ID="btnEntrar" CssClass="btn bg-green mt-3" runat="server" Text="Entrar" />
                    </form>
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
