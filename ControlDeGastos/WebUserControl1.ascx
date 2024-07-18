<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="ControlDeGastos.WebUserControl1" %>

<nav class="navbar navbar-expand-lg bg-body-tertiary">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">Bienvenido <asp:Label ID="lblWelcome" runat="server"></asp:Label></a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                </li>
                <li class="nav-item">
                    <asp:Button Class="nav-link" ID="btnSignUp" Visible="true" runat="server" Text="SignUp" OnClick="btnGoToSignUp_Click" />
                </li>
                <li class="nav-item">
                    <asp:Button  Class="nav-link" ID="btnLogIn" Visible="true" runat="server" Text="Login" OnClick="btnGoToLoginUp_Click" />
                </li>
                <li class="nav-item">
                    <asp:Button  Class="nav-link" ID="btnLogout" runat="server" Text="Desloguearse" OnClick="btnLogout_Click" Visible="false"/>
                </li>
            </ul>
        </div>
    </div>
</nav>
        
