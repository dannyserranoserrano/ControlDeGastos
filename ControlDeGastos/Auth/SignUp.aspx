<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ControlDeGastos.SignUp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Crear Usuario</h2>
            <asp:TextBox TextMode="SingleLine" ID="txtUsername" runat="server" placeholder="Usuario"></asp:TextBox>
            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnSignUp" runat="server" Text="Sign In" OnClick="btnSignUp_Click" />
            <br /><br />
            <asp:Label ID="lblErrorMessage" runat="server" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
        </div>
</asp:Content>
