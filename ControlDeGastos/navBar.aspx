<%@ Page Title="navBar" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="navBar.aspx.cs" Inherits="ControlDeGastos.buttons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Contenido del titulo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <div class="container">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" runat="server" href="~/">Control de Gastos</a>
        <asp:Button ID="btnSignUp" Visible="true" runat="server" Text="SignUp" OnClick="btnGoToSignUp_Click" />
        <asp:Button ID="btnLogIn" Visible="true" runat="server" Text="Login" OnClick="btnGoToLoginUp_Click" />
        <asp:Button ID="btnLogout" runat="server" Text="Desloguearse" OnClick="btnLogout_Click" />
        <asp:Label ID="lblWelcome" runat="server"></asp:Label>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
        <p>Contenido adicional del footer</p>
</asp:Content>
