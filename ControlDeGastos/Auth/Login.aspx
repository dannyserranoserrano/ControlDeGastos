<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlDeGastos.Login" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h3>No tienes cuenta? Registrate</h3>
            <asp:Button ID="btnSign" runat="server" Text="SignUp " OnClick="btnGoToSignUp_Click" />
        </div>

        <div>
            <h2>Iniciar Sesión</h2>
            <asp:TextBox TextMode="SingleLine" ID="txtUsername" runat="server" placeholder="Usuario"></asp:TextBox>
            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
